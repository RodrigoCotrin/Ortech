package br.teste.fragments;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import br.teste.R;
import br.teste.adapters.CarrinhoAdapter;
import br.teste.classes.Carrinho;
import br.teste.classes.ConexaoSQL;
import br.teste.classes.Id_Func;
import br.teste.classes.PegarLista;
import br.teste.classes.ProductMesa;
import br.teste.classes.Produtos;
import br.teste.classes.RealizaPedido;
import br.teste.databinding.FragmentCarrinhoBinding;


public class CarrinhoFragment extends Fragment {
    FragmentCarrinhoBinding binding;
    List<Carrinho> produtosNoCarrinho = new ArrayList<>();
    CarrinhoAdapter adapter1;
    Carrinho carrinho1;
    ConexaoSQL conexaoSQL;
    Connection connection;
    ProductMesa productMesa = new ProductMesa();
    Id_Func idFunc = new Id_Func();
    public CarrinhoFragment() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentCarrinhoBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        /////////////////////////////
        ArrayAdapter<String> formaPag = new ArrayAdapter<>(getContext(), android.R.layout.simple_spinner_item);

        formaPag.add("Dinheiro");
        formaPag.add("Cartão de Crédito");
        formaPag.add("Cartão de Débito");
        formaPag.add("PIX");

        binding.formaPagamento.setAdapter(formaPag);
        //////////////////////////////

        //////////////////////////////
        List<Produtos> produtos = PegarLista.getInstance().getListaProdutos();

        ArrayAdapter<String> adapter = new ArrayAdapter<>(getContext(), android.R.layout.simple_spinner_item);

        formaPag.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        for (Produtos produto : produtos) {adapter.add(produto.getNomeProduto());}

        binding.spinner.setAdapter(adapter);
        //////////////////////////////////////

        String numeroMesa = productMesa.getNum_mesa();

        binding.numeroMesa1.setText("Mesa " + numeroMesa);
        //////////////////////////////////////////////////////////////////////////

        adapter1 = new CarrinhoAdapter(getContext(), produtosNoCarrinho);

        binding.listproduto.setAdapter(adapter1);

        binding.listproduto.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, final int posicao, long id) {
                final Carrinho carrinho = (Carrinho) adapter1.getItem(posicao);

                AlertDialog.Builder janela = new AlertDialog.Builder(getContext());
                janela.setTitle("Escolha:");
                janela.setMessage("Deseja remover o item " + carrinho.getNomeProduto() + "?");

                janela.setNegativeButton("Não", null);

                janela.setPositiveButton("Sim", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        boolean exclui = false;

                        exclui = adapter1.removerItem(posicao, binding.listproduto);

                        double total = calcularTotaldeVenda(produtosNoCarrinho);
                        atualizarTotal(total);

                        if(!exclui){
                            Toast.makeText(getContext(), "Erro ao excluir", Toast.LENGTH_SHORT).show();
                        }
                    }
                });
                janela.create().show();
            }
        });
        return view;
    }


    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.btnAdicionar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String valor = null;
                String id_produto = null;
                int quantidade = 0;
                if (!binding.txtQtde.getText().toString().equals("")) {
                    quantidade = Integer.parseInt(binding.txtQtde.getText().toString());
                } else {
                    quantidade = 1;
                }

                String produto = binding.spinner.getSelectedItem().toString();

                conexaoSQL = new ConexaoSQL();
                connection = conexaoSQL.connectionclass();
                Statement st = conexaoSQL.createStatement(connection);

                try {
                    ResultSet rs = st.executeQuery("SELECT preco, id_produto FROM Produtos where nome_produto = '" + produto + "'");
                    if (rs.next()) {
                        valor = rs.getString(1);
                        id_produto = rs.getString(2);

                        // Verifique se o valor não é nulo antes de converter
                        if (valor != null) {
                            Double valorTotal = Double.parseDouble(valor) * quantidade;

                            // Verificar se o produto já existe no carrinho
                            boolean produtoJaExiste = false;
                            Carrinho produtoExistente = null;

                            for (Carrinho item : produtosNoCarrinho) {
                                if (item.getNomeProduto().equals(produto)) {
                                    produtoJaExiste = true;
                                    produtoExistente = item;
                                    break;
                                }
                            }

                            if (produtoJaExiste) {
                                // O produto já existe no carrinho, atualize a quantidade e o valor total
                                int novaQuantidade = produtoExistente.getQuantidade() + quantidade;
                                double novoValorTotal = produtoExistente.getValorqtde() + valorTotal;
                                produtoExistente.setQuantidade(novaQuantidade);
                                produtoExistente.setValorqtde(novoValorTotal);
                            } else {
                                // O produto não existe no carrinho, adicione-o
                                carrinho1 = new Carrinho(produto, quantidade, valorTotal, id_produto);
                                adapter1.addItem(carrinho1);
                            }

                            adapter1.updateListViewHeight(binding.listproduto);
                        } else {
                            // Lidar com o caso em que o valor seja nulo
                            // Por exemplo, exiba uma mensagem de erro ou defina um valor padrão
                        }
                        double total = calcularTotaldeVenda(produtosNoCarrinho);
                        atualizarTotal(total);
                        adapter1.notifyDataSetChanged();
                    }
                } catch (SQLException e) {
                    throw new RuntimeException(e);
                }
            }
        });

        binding.voltar1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {openChildFragment();}
        });

        binding.btnrealizaPedido.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                RealizaPedido vendafechada = criarVenda();

                if (vendafechada != null) {
                    if (salvarVenda(vendafechada)) {
                        try
                        {
                            //arrays para idProdutos e quantidades
                            int[] idProdutos = new int[produtosNoCarrinho.size()];
                            int[] quantidades = new int[produtosNoCarrinho.size()];

                            // Preenche os arrays conforme o listview
                            for (int i = 0; i < produtosNoCarrinho.size(); i++) {
                                Carrinho produto = produtosNoCarrinho.get(i);
                                idProdutos[i] = Integer.parseInt(produto.getId_produto());
                                quantidades[i] = produto.getQuantidade();
                            }

                            String inserirSql = "DECLARE @produtos dbo.ProdutosType ";
                            for (int i = 0; i < idProdutos.length; i++) {
                                inserirSql += "INSERT INTO @produtos (id_produto, quantidade_produto) VALUES (?, ?) ";
                            }

                            inserirSql += "EXEC usp_InserirPedidoFunc " +
                                    "@id_funcionario = "+ Id_Func.getIdFunc() +","  +
                                    "@data_pedido = '"+ vendafechada.getDataPedido() +"', " +
                                    "@formapagamento = '"+ binding.formaPagamento.getSelectedItem().toString() +"', " +
                                    "@numero_mesa = " + productMesa.getNum_mesa() +", " +
                                    "@produtos = @produtos";

                            PreparedStatement insertDataStatement = connection.prepareStatement(inserirSql);

                            //adiciona os valores do @produtos
                            int Index = 1;
                            for (int i = 0; i < idProdutos.length; i++) {
                                insertDataStatement.setInt(Index++, idProdutos[i]);
                                insertDataStatement.setInt(Index++, quantidades[i]);
                            }

                            insertDataStatement.executeUpdate();

                            conexaoSQL.closeConnection(connection);
                        } catch (SQLException e) {
                            e.printStackTrace();
                        }

                        Toast.makeText(getContext(), "Pedido Realizado", Toast.LENGTH_SHORT).show();
                        openChildFragment2();
                    } else {
                        Toast.makeText(getContext(), "Erro ao fechar a venda", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    Toast.makeText(getContext(), "Não é possível fechar a venda, pois o carrinho está vazio", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }
    private double calcularTotaldeVenda(List<Carrinho> gprodutosNoCarrinho){
        double totalVenda = 0.0;

        for(Carrinho carrinho : gprodutosNoCarrinho){
            totalVenda += carrinho.getValorqtde();
        }

        return totalVenda;
    }

    private void atualizarTotal(double pValorTotal){
        binding.valorTotal.setText("R$ " + String.format("%.2f", pValorTotal));
    }

    private RealizaPedido criarVenda(){
        RealizaPedido realizaPedido = new RealizaPedido();

        if (produtosNoCarrinho != null && !produtosNoCarrinho.isEmpty()) {
            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
            Date dataAtual = new Date();
            String dataFormatada = dateFormat.format(dataAtual);
            realizaPedido.setDataPedido(dataFormatada);
            realizaPedido.setFormapagamento(binding.formaPagamento.getSelectedItem().toString());
            realizaPedido.setPedidosProduto(produtosNoCarrinho);
            realizaPedido.setNumeroMesa(productMesa.getNum_mesa());
            realizaPedido.setId_func(Id_Func.getIdFunc());

            // Agora, você pode prosseguir com o processamento da venda
            return realizaPedido;
        } else {
            return null; // Ou qualquer outra ação apropriada, como retornar null ou outro valor adequado
        }
    }

    private boolean salvarVenda(RealizaPedido realizaPedido){
        Log.d("Venda", realizaPedido.getDataPedido().toString());

        return true;
    }

    private void openChildFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram2, new TelaMesaFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

    private void openChildFragment2() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram2, new TelaMesaOcupadaFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
}