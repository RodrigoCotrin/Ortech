package br.teste.fragments;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import br.teste.adapters.HistoricoPedidoAdapter;
import br.teste.classes.ConexaoSQL;
import br.teste.classes.HistoricoPedidos;
import br.teste.classes.ProductMesa;
import br.teste.R;
import br.teste.databinding.FragmentHistoricoDePedidosBinding;

public class HistoricoDePedidosFragment extends Fragment {
    FragmentHistoricoDePedidosBinding binding;
    ProductMesa productMesa;
    HistoricoPedidoAdapter HistoricoPedidoAdapter;
    List<HistoricoPedidos> historicopedidos = new ArrayList<HistoricoPedidos>();
    ConexaoSQL conexaoSQL;
    Connection connection;
    public HistoricoDePedidosFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentHistoricoDePedidosBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        productMesa = new ProductMesa();
        String numero_mesa = productMesa.getNum_mesa();
        binding.numeroMesa1.setText("Mesa "+numero_mesa);

        this.criarHistorico();

        HistoricoPedidoAdapter = new HistoricoPedidoAdapter(historicopedidos);
        RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(getContext());
        binding.recycler.setLayoutManager(layoutManager);
        binding.recycler.setHasFixedSize(true);
        binding.recycler.setAdapter(HistoricoPedidoAdapter);


        return view;
    }
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        binding.voltar1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openChildFragment();
            }
        });

    }
    private void openChildFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram2, new TelaMesaFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

    public void criarHistorico(){

        conexaoSQL = new ConexaoSQL();
        connection = conexaoSQL.connectionclass();
        Statement st = conexaoSQL.createStatement(connection);
        String consulta = "SELECT \n" +
                "    p.id_pedido,\n" +
                "    c.cpf,\n" +
                "    f.id_funcionario,\n" +
                "    p.valor_total,\n" +
                "    CONVERT(varchar, p.data_pedido, 103) as data_pedido,\n" +
                "    COUNT(dp.id_produto) as quantidade_produtos\n" +
                "FROM Pedido p\n" +
                "LEFT JOIN Cliente c ON p.cpf = c.cpf\n" +
                "LEFT JOIN Funcionario f ON p.id_funcionario = f.id_funcionario\n" +
                "LEFT JOIN DetalhesPedido dp ON p.id_pedido = dp.id_pedido\n" +
                "WHERE p.numero_mesa = "+ productMesa.getNum_mesa() +
                "GROUP BY \n" +
                "    p.id_pedido,\n" +
                "    c.cpf,\n" +
                "    f.id_funcionario, \n" +
                "    p.valor_total,\n" +
                "    p.data_pedido;";
        String cpfOuId;
        try {
            ResultSet rs = st.executeQuery(consulta);
            while (rs.next()) {
                HistoricoPedidos historicoDePedidos = new HistoricoPedidos("", "", "", null, "");

                if (rs.getString("cpf") != null) {
                    cpfOuId = rs.getString("cpf");
                } else {
                    cpfOuId = rs.getString("id_funcionario");
                }
                historicoDePedidos.setCpf(cpfOuId);
                historicoDePedidos.setValor("R$ "+rs.getString("valor_total"));
                historicoDePedidos.setNum_ped(rs.getString("id_pedido"));
                historicoDePedidos.setData(rs.getString("data_pedido"));
                historicoDePedidos.setNum_item(rs.getString("quantidade_produtos"));
                historicopedidos.add(historicoDePedidos);
            }
        } catch (SQLException e) {throw new RuntimeException(e);}
    }
}