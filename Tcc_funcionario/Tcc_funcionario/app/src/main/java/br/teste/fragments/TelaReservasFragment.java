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

import br.teste.R;
import br.teste.adapters.ReservaAdapter;
import br.teste.classes.ConexaoSQL;
import br.teste.classes.ProductMesa;
import br.teste.classes.Reservas;
import br.teste.databinding.FragmentTelaReservasBinding;

public class TelaReservasFragment extends Fragment {

    FragmentTelaReservasBinding binding;
    ConexaoSQL conexaoSQL;
    Connection connection;
    ProductMesa productMesa;
    ReservaAdapter ReservaAdapter;
    List<Reservas> reservas = new ArrayList<Reservas>();
    public TelaReservasFragment() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentTelaReservasBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        productMesa = new ProductMesa();
        int numero_mesa = productMesa.getNum_mesa1();
        binding.numMesa.setText("mesa "+numero_mesa);

        this.gerarReservas();

        ReservaAdapter = new ReservaAdapter(reservas);
        RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(getContext());
        binding.recycler1.setLayoutManager(layoutManager);
        binding.recycler1.setHasFixedSize(true);
        binding.recycler1.setAdapter(ReservaAdapter);

        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.voltar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(productMesa.getClique() == 0){
                openChildFragment();}
                if(productMesa.getClique() == 1){
                    openChildFragment1();
                }
            }
        });

    }

    public void gerarReservas(){
        conexaoSQL = new ConexaoSQL();
        connection = conexaoSQL.connectionclass();
        Statement st = conexaoSQL.createStatement(connection);
        String consulta = "select c.nome, p.quantidade_pessoas, Convert(varchar, p.data_reserva, 103) as data, FORMAT(p.data_reserva, 'HH:mm') AS horario_reserva from Reserva" +
                " p LEFT JOIN Cliente c ON p.cpf = c.cpf where numero_mesa = " + productMesa.getNum_mesa1()
                + " AND data_reserva > GETDATE() order by data, horario_reserva asc";
        try {
            ResultSet rs = st.executeQuery(consulta);
            while (rs.next()) {
                Reservas reserva = new Reservas("", "", "", "");
                reserva.setCpf(rs.getString(1));
                reserva.setDataReserva(rs.getString("data"));
                reserva.setQuantidadePessoas(rs.getString(2));
                reserva.setHorareserva(rs.getString("horario_reserva"));
                reservas.add(reserva);
            }
        } catch (SQLException e) {throw new RuntimeException(e);}
    }
    private void openChildFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame10, new ReservaFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
    private void openChildFragment1() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame10, new TelaMesaFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
}