package br.teste.fragments;

import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import br.teste.R;
import br.teste.classes.ConexaoSQL;
import br.teste.classes.ProductMesa;
import br.teste.databinding.FragmentReservaBinding;

public class ReservaFragment extends Fragment {

    FragmentReservaBinding binding;
    ProductMesa productMesa;
    int mesa = 0;
    ConexaoSQL conexaoSQL;
    Connection connection;
    public ReservaFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentReservaBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        productMesa.setClique(0);
        this.AtualizarStatus();


        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.mesa1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 1;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 2;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 3;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 4;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa5.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 5;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa6.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 6;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa7.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 7;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa8.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 8;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa9.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 9;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa10.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 10;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa11.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 11;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa12.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 12;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa13.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 13;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa14.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 14;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa15.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 15;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa16.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 16;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa17.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 17;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
        binding.mesa18.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mesa = 18;
                productMesa.setNum_mesa1(mesa);
                openChildFragment();
            }
        });
    }

    public void AtualizarStatus(){
        conexaoSQL = new ConexaoSQL();
        connection = conexaoSQL.connectionclass();
        Statement st = conexaoSQL.createStatement(connection);
        String con1, con2, con3, con4, con5, con6, con7, con8, con9, con10,
                con11, con12, con13, con14, con15, con16, con17, con18;

        con1 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 1 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {
            ResultSet rs = st.executeQuery(con1);
            if (rs.next()) {String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa1.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (
                SQLException e) {throw new RuntimeException(e);}

        con2 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 2 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con2);
            if (rs.next()){String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa2.setBackgroundColor(Color.argb(100,0,255,255));}}} catch (SQLException e) {throw new RuntimeException(e);}

        con3 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 3 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con3);
            if (rs.next()) {String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa3.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con4 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 4 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con4);if (rs.next()){String status = rs.getString(1);
            if(!"".equals(status)){binding.mesa4.setBackgroundColor(Color.argb(100,0,255,255));}}} catch (SQLException e) {throw new RuntimeException(e);}

        con5 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 5 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con5);if (rs.next()) {String status = rs.getString(1);
            if(!"".equals(status)){binding.mesa5.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con6 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 6 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con6);if (rs.next()){String status = rs.getString(1);
            if(!"".equals(status)){binding.mesa6.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con7 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 7 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con7);
            if (rs.next()) {String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa7.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con8 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 8 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con8);
            if (rs.next()){String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa8.setBackgroundColor(Color.argb(100,0,255,255));}}} catch (SQLException e) {throw new RuntimeException(e);}

        con9 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 9 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con9);if (rs.next()) {String status = rs.getString(1);
            if(!"".equals(status)){binding.mesa9.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con10 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 10 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con10);if (rs.next()){String status = rs.getString(1);
            if(!"".equals(status)){binding.mesa10.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con11 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 11 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con11);
            if (rs.next()) {String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa11.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con12 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 12 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con12);
            if (rs.next()){String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa12.setBackgroundColor(Color.argb(100,0,255,255));}}} catch (SQLException e) {throw new RuntimeException(e);}

        con13 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 13 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con13);
            if (rs.next()) {String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa13.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con14 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 14 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con14);
            if (rs.next()){String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa14.setBackgroundColor(Color.argb(100,0,255,255));}}} catch (SQLException e) {throw new RuntimeException(e);}

        con15 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 15 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con15);if (rs.next()) {String status = rs.getString(1);
            if(!"".equals(status)){binding.mesa15.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con16 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 16 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con16);if (rs.next()){String status = rs.getString(1);
            if(!"".equals(status)){binding.mesa16.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con17 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 17 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con17);
            if (rs.next()) {String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa17.setBackgroundColor(Color.argb(100,0,255,255));}}}catch (SQLException e) {throw new RuntimeException(e);}

        con18 = "SELECT \n" +
                "    CONVERT(varchar, data_reserva, 103) as data, \n" +
                "    FORMAT(data_reserva, 'HH:mm') AS horario_reserva \n" +
                "FROM \n" +
                "    Reserva \n" +
                "WHERE \n" +
                "    numero_mesa = 18 \n" +
                "    AND data_reserva >= GETDATE() \n" +
                "    AND data_reserva <= DATEADD(HOUR, 1, GETDATE());";
        try {ResultSet rs = st.executeQuery(con18);
            if (rs.next()){String status = rs.getString(1);
                if(!"".equals(status)){binding.mesa18.setBackgroundColor(Color.argb(100,0,255,255));}}} catch (SQLException e) {throw new RuntimeException(e);}
    }

    private void openChildFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame10, new TelaReservasFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
}
