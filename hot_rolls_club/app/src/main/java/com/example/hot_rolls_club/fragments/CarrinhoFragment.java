package com.example.hot_rolls_club.fragments;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.LinearLayoutManager;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.activities.PedidoFeito;
import com.example.hot_rolls_club.adapters.CartAdapter;
import com.example.hot_rolls_club.adapters.RecyclerProdutosInterface;
import com.example.hot_rolls_club.classes.Carrinho;
import com.example.hot_rolls_club.classes.CartItems;
import com.example.hot_rolls_club.classes.ConexaoSQL;
import com.example.hot_rolls_club.classes.ContaCli;
import com.example.hot_rolls_club.classes.ProductMesa;
import com.example.hot_rolls_club.classes.Produtos;
import com.example.hot_rolls_club.classes.RealizaPedido;
import com.example.hot_rolls_club.databinding.FragmentCarrinhoBinding;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;


public class CarrinhoFragment extends Fragment {
    FragmentCarrinhoBinding binding;
    RecyclerProdutosInterface recyclerProdutosInterface;

    ArrayAdapter<String> mesas;

    private Timer timer;
    ProductMesa productMesa;
    CartAdapter cartAdapter;
    List<Produtos> cartItems;

    Connection connection;

    ConexaoSQL conexaoSQL;
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

        cartItems = CartItems.getCartItems();

        LinearLayoutManager layoutManager = new LinearLayoutManager(getContext());
        binding.view.setLayoutManager(layoutManager);
        GridLayoutManager gridLayoutManager = new GridLayoutManager(getContext(), 1);
        binding.view.setLayoutManager(gridLayoutManager);
        binding.view.setHasFixedSize(true);

        cartAdapter = new CartAdapter(cartItems);
        binding.view.setAdapter(cartAdapter);

        ArrayAdapter<String> mesas = new ArrayAdapter<>(getContext(), android.R.layout.simple_spinner_item);
        mesas.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        for (int mesa = 1; mesa < 19; mesa++){
            mesas.add("Mesa " + mesa);
        }
        binding.escolherMesa.setAdapter(mesas);

        calcularPrecoTotal();
        verificarItensDuplicados();
        return view;
    }


    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        timer = new Timer();
        timer.scheduleAtFixedRate(new TimerTask() {
            @Override
            public void run() {
                calcularPrecoTotal();
            }
        }, 0, 100);

        binding.btnDinheiro.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(binding.btnDinheiro.isChecked()){
                    binding.btnCredito.setChecked(false);
                    binding.btnPix.setChecked(false);
                    binding.btnDebito.setChecked(false);
                }
            }
        });
        binding.btnCredito.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(binding.btnCredito.isChecked()){
                    binding.btnDinheiro.setChecked(false);
                    binding.btnPix.setChecked(false);
                    binding.btnDebito.setChecked(false);
                }
            }
        });
        binding.btnPix.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(binding.btnPix.isChecked()){
                    binding.btnCredito.setChecked(false);
                    binding.btnDinheiro.setChecked(false);
                    binding.btnDebito.setChecked(false);
                }
            }
        });
        binding.btnDebito.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                binding.btnCredito.setChecked(false);
                binding.btnDinheiro.setChecked(false);
                binding.btnPix.setChecked(false);
            }
        });

        binding.btnFazerPedido.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                RealizaPedido vendafechada = criarVenda();

                String mesaSelecionada = (String) binding.escolherMesa.getSelectedItem();

                String numeroMesa = mesaSelecionada.replace("Mesa ", "");


                if ((!binding.btnCredito.isChecked() && !binding.btnPix.isChecked()
                        && !binding.btnDinheiro.isChecked() && !binding.btnDebito.isChecked()))
                    Toast.makeText(getContext(), "Selecione um método de pagamento", Toast.LENGTH_SHORT).show();


                String botao = "";
                if (binding.btnCredito.isChecked())
                    botao = "Cartão de Crédito";
                if (binding.btnPix.isChecked())
                    botao = "Pix";
                if (binding.btnDinheiro.isChecked())
                    botao = "Dinheiro";
                if (binding.btnDebito.isChecked())
                    botao = "Cartão de Débito";


                if (vendafechada != null) {
                    if (salvarVenda(vendafechada)) {

                        conexaoSQL = new ConexaoSQL();
                        connection = conexaoSQL.connectionclass();

                        try
                        {
                            List<Produtos> produtosNoCarrinho = cartAdapter.getCartItems();

                            List<Carrinho> carrinhoItems = new ArrayList<>();

                            for (Produtos produto : produtosNoCarrinho) {
                                int quantidade = produto.getQuantidadeSelecionada();
                                Carrinho carrinho = new Carrinho(quantidade, produto.getId_produto());
                                carrinhoItems.add(carrinho);
                            }


                            //arrays para idProdutos e quantidades
                            int[] idProdutos = new int[cartItems.size()];
                            int[] quantidades = new int[cartItems.size()];

                            // Preenche os arrays conforme o listview
                            for (int i = 0; i < carrinhoItems.size(); i++) {
                                Carrinho produto = carrinhoItems.get(i);
                                idProdutos[i] = Integer.parseInt(produto.getId_produto());
                                quantidades[i] = produto.getQuantidade();
                            }

                            String inserirSql = "DECLARE @produtos dbo.ProdutosType ";
                            for (int i = 0; i < idProdutos.length; i++) {
                                inserirSql += "INSERT INTO @produtos (id_produto, quantidade_produto) VALUES (?, ?) ";
                            }

                            inserirSql += "EXEC usp_InserirPedido " +
                                    "@cpf = "+ ContaCli.getCpf() +","  +
                                    "@data_pedido = '"+ vendafechada.getDataPedido() +"', " +
                                    "@formapagamento = '"+ botao +"', " +
                                    "@numero_mesa = " + numeroMesa +", " +
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

                        cartItems.clear();
                        Intent intent = new Intent(getContext(), PedidoFeito.class);
                        startActivity(intent);

                    } else {
                        Toast.makeText(getContext(), "Erro ao fechar a venda", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    Toast.makeText(getContext(), "Não é possível fechar a venda, pois o carrinho está vazio", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    private RealizaPedido criarVenda(){
        RealizaPedido realizaPedido = new RealizaPedido();

        String mesaSelecionada = (String) binding.escolherMesa.getSelectedItem();

        String numeroMesa = mesaSelecionada.replace("Mesa ", "");

        String botao = "";
        if (binding.btnCredito.isChecked())
            botao = "Cartão de Crédito";
        if (binding.btnPix.isChecked())
            botao = "Pix";
        if (binding.btnDinheiro.isChecked())
            botao = "Dinheiro";
        if (binding.btnDebito.isChecked())
            botao = "Cartão de Débito";

        if (cartItems != null && !cartItems.isEmpty()) {
            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
            Date dataAtual = new Date();
            String dataFormatada = dateFormat.format(dataAtual);
            realizaPedido.setDataPedido(dataFormatada);
            realizaPedido.setFormapagamento(botao);
            realizaPedido.setPedidosProduto(cartItems);
            realizaPedido.setNumeroMesa(numeroMesa);
            realizaPedido.setCpf(ContaCli.getCpf());

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
    private void calcularPrecoTotal() {
        BigDecimal precoTotal = BigDecimal.ZERO;

        for (Produtos produto : cartItems) {
            int quantidade = produto.getQuantidadeSelecionada();
            BigDecimal precoUnitario = new BigDecimal(produto.getPrecoProduto().replace("R$", "").trim());
            BigDecimal precoItem = precoUnitario.multiply(BigDecimal.valueOf(quantidade));
            precoTotal = precoTotal.add(precoItem);
        }
        BigDecimal finalPrecoTotal = precoTotal;
        requireActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {
                binding.txtPrecoTotal.setText("R$ " + finalPrecoTotal.setScale(2, RoundingMode.HALF_UP).toString());
            }
        });
    }

    // Lembre-se de cancelar o TimerTask quando a Fragment for pausada ou destruída para evitar vazamento de memória:
    @Override
    public void onPause() {
        super.onPause();
        stopAutomaticUpdate();
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        stopAutomaticUpdate();
    }

    // Método para parar o TimerTask
    private void stopAutomaticUpdate() {
        if (timer != null) {
            timer.cancel();
            timer = null;
        }
    }

    private void verificarItensDuplicados() {
        List<Produtos> itensDuplicados = new ArrayList<>();

        for (int i = 0; i < cartItems.size() - 1; i++) {
            Produtos produtoAtual = cartItems.get(i);

            for (int j = i + 1; j < cartItems.size(); j++) {
                Produtos produtoComparado = cartItems.get(j);

                if (produtoAtual.getNomeProduto().equals(produtoComparado.getNomeProduto())) {
                    // Se houver um produto duplicado, atualize a quantidade no produto atual
                    produtoAtual.setQuantidadeSelecionada(produtoAtual.getQuantidadeSelecionada() + produtoComparado.getQuantidadeSelecionada());

                    // Adicione o item duplicado à lista para remoção posterior
                    if (!itensDuplicados.contains(produtoComparado)) {
                        itensDuplicados.add(produtoComparado);
                    }
                }
            }
        }
        cartItems.removeAll(itensDuplicados);

        if (cartAdapter != null) {
            cartAdapter.notifyDataSetChanged();
        }
    }

    private void openFragmentTelaInicial() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram10, new InicioFragment());
        fragmentTransaction.commit();
    }
}