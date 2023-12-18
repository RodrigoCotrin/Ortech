package br.teste.fragments;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
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
import android.widget.Toast;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import br.teste.adapters.PedidoAdapter;
import br.teste.classes.ConexaoSQL;
import br.teste.classes.ImageConverterToBD;
import br.teste.classes.Pedido;
import br.teste.classes.ProductMesa;
import br.teste.R;
import br.teste.databinding.FragmentTelaMesaOcupadaBinding;

public class TelaMesaOcupadaFragment extends Fragment {
    FragmentTelaMesaOcupadaBinding binding;
    ProductMesa productMesa = new ProductMesa();
    PedidoAdapter PedidoAdapter;
    List<Pedido> pedido = new ArrayList<Pedido>();
    ConexaoSQL conexaoSQL;
    Connection connection;
    String hora, status;
    String nomeCli = "";
    String consulta1 = "SELECT TOP 1\n" +
            "    c.nome\n" +
            "FROM Pedido p\n" +
            "JOIN DetalhesPedido dp ON p.id_pedido = dp.id_pedido\n" +
            "JOIN Produtos pr ON dp.id_produto = pr.id_produto\n" +
            "JOIN StatusPedido sp ON p.id_pedido = sp.id_pedido\n" +
            "JOIN Cliente c ON p.cpf = c.cpf\n" +
            "WHERE p.id_pedido = (SELECT MAX(id_pedido) FROM Pedido WHERE numero_mesa = "+ productMesa.getNum_mesa()+")ORDER BY dp.id_pedido, dp.id_produto;";

    public TelaMesaOcupadaFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentTelaMesaOcupadaBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        //ImageConverterToBD.insertImageIntoDatabase(getContext(), R.drawable.yaki);

        conexaoSQL = new ConexaoSQL();
        connection = conexaoSQL.connectionclass();
        Statement st = conexaoSQL.createStatement(connection);

        try {
            ResultSet rs1 = st.executeQuery(consulta1);
            if(rs1.next()){nomeCli = rs1.getString(1);}
            if(nomeCli != ""){binding.cliente.setText("Mesa ocupada por "+nomeCli);}
            else if(nomeCli == ""){
                nomeCli = "Pedido da mesa realizado por Funcionario";
                binding.cliente.setText(nomeCli);
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
        binding.numeroMesa1.setText("Mesa "+productMesa.getNum_mesa());
        this.criarPedido();

        PedidoAdapter = new PedidoAdapter(pedido);
        RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(getContext());
        binding.recycler.setLayoutManager(layoutManager);
        binding.recycler.setHasFixedSize(true);
        binding.recycler.setAdapter(PedidoAdapter);

        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);


        conexaoSQL = new ConexaoSQL();
        connection = conexaoSQL.connectionclass();
        Statement st = conexaoSQL.createStatement(connection);

        binding.voltar1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {openChildFragment();}
        });
        binding.btnDesocupa.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ImageConverterToBD.insertImageIntoDatabaseFunc(getContext(), R.drawable.img);
                String desocupa = "UPDATE Mesa " +
                        "SET status_mesa = 'Disponível' " +
                        "WHERE numero_mesa = " + productMesa.getNum_mesa();
                try
                {
                    int linhas = st.executeUpdate(desocupa);
                    if(linhas>0)
                    {
                      Toast.makeText(getContext(), "Mesa Disponível", Toast.LENGTH_SHORT).show();
                      openChildFragment();
                    }else{Toast.makeText(getContext(), "Erro ao atualizar a mesa", Toast.LENGTH_SHORT).show();}
                } catch (SQLException e) {throw new RuntimeException(e);}
            }
        });
    }

    private void openChildFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram2, new MesasFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

    public void criarPedido(){
        conexaoSQL = new ConexaoSQL();
        connection = conexaoSQL.connectionclass();
        Statement st = conexaoSQL.createStatement(connection);
        String consulta = "SELECT p.id_pedido, pr.img_prato," +
                " pr.nome_produto," +
                " dp.quantidade_produto," +
                " CONVERT(VARCHAR(5), p.data_pedido, 108) AS hora_pedido, sp.status_pedido " +
                "FROM Pedido p" +
                " JOIN DetalhesPedido dp ON p.id_pedido = dp.id_pedido " +
                "JOIN Produtos pr ON dp.id_produto = pr.id_produto " +
                "JOIN StatusPedido sp ON p.id_pedido = sp.id_pedido" +
                " WHERE p.id_pedido = (SELECT MAX(id_pedido) FROM Pedido WHERE numero_mesa = "+ productMesa.getNum_mesa()+")" +
                " ORDER BY dp.id_pedido, dp.id_produto;";
        try {
            ResultSet rs = st.executeQuery(consulta);

            while (rs.next()){
                Pedido pedido1 = new Pedido("","", null); // Crie um novo objeto Pedido para cada iteração
                byte[] imageData = rs.getBytes("img_prato");
                Bitmap imageBitmap = BitmapFactory.decodeByteArray(imageData, 0, imageData.length);
                pedido1.setImg(imageBitmap);
                pedido1.setNome_prato(rs.getString("nome_produto"));
                pedido1.setQuantidade(rs.getString("quantidade_produto"));
                hora = rs.getString("hora_pedido");
                status = rs.getString("status_pedido");

                pedido.add(pedido1);
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
        binding.statushora.setText(status +" "+ hora);
    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

}