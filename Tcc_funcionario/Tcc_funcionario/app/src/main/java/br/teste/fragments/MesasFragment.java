package br.teste.fragments;

import android.graphics.Color;
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

import br.teste.classes.ConexaoSQL;
import br.teste.classes.ProductMesa;
import br.teste.R;

import br.teste.databinding.FragmentMesasBinding;

import java.sql.Statement;

public class MesasFragment extends Fragment {
    FragmentMesasBinding binding;
    ConexaoSQL conexaoSQL;
    Connection connection;
    ProductMesa productMesa;
    String ocu1, ocu2, ocu3, ocu4, ocu5, ocu6, ocu7, ocu8, ocu9, ocu10,
            ocu11, ocu12, ocu13, ocu14, ocu15, ocu16, ocu17, ocu18;
    public MesasFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentMesasBinding.inflate(inflater, container, false);
        View view = binding.getRoot();
        productMesa = new ProductMesa();
        AtualizarButton();
        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.mesa1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "1";
                productMesa.setNum_mesa(mesa);
                if(ocu1.equals("ocupada")){
                    openFragment1();}
                if(ocu1.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "2";
                productMesa.setNum_mesa(mesa);
                if(ocu2.equals("ocupada")){
                    openFragment1();}
                if(ocu2.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "3";
                productMesa.setNum_mesa(mesa);
                if(ocu3.equals("ocupada")){
                    openFragment1();}
                if(ocu3.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "4";
                productMesa.setNum_mesa(mesa);
                if(ocu4.equals("ocupada")){
                    openFragment1();}
                if(ocu4.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa5.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "5";
                productMesa.setNum_mesa(mesa);
                if(ocu5.equals("ocupada")){
                    openFragment1();}
                if(ocu5.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa6.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "6";
                productMesa.setNum_mesa(mesa);
                if(ocu6.equals("ocupada")){
                    openFragment1();}
                if(ocu6.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa7.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "7";
                productMesa.setNum_mesa(mesa);
                if(ocu7.equals("ocupada")){
                    openFragment1();}
                if(ocu7.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa8.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "8";
                productMesa.setNum_mesa(mesa);
                if(ocu8.equals("ocupada")){
                    openFragment1();}
                if(ocu8.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa9.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "9";
                productMesa.setNum_mesa(mesa);
                if(ocu9.equals("ocupada")){
                    openFragment1();}
                if(ocu9.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa10.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "10";
                productMesa.setNum_mesa(mesa);
                if(ocu10.equals("ocupada")){
                    openFragment1();}
                if(ocu10.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa11.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "11";
                productMesa.setNum_mesa(mesa);
                if(ocu11.equals("ocupada")){
                    openFragment1();}
                if(ocu11.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa12.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "12";
                productMesa.setNum_mesa(mesa);
                if(ocu12.equals("ocupada")){
                    openFragment1();}
                if(ocu12.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa13.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "13";
                productMesa.setNum_mesa(mesa);
                if(ocu13.equals("ocupada")){
                    openFragment1();}
                if(ocu13.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa14.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "14";
                productMesa.setNum_mesa(mesa);
                if(ocu14.equals("ocupada")){
                    openFragment1();}
                if(ocu14.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa15.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "15";
                productMesa.setNum_mesa(mesa);
                if(ocu15.equals("ocupada")){
                    openFragment1();}
                if(ocu15.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa16.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "16";
                productMesa.setNum_mesa(mesa);
                if(ocu16.equals("ocupada")){
                    openFragment1();}
                if(ocu16.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa17.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "17";
                productMesa.setNum_mesa(mesa);
                if(ocu17.equals("ocupada")){
                    openFragment1();}
                if(ocu17.equals("")){
                    openFragment();
                }
            }
        });
        binding.mesa18.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String mesa = "18";
                productMesa.setNum_mesa(mesa);
                if(ocu18.equals("ocupada")){
                    openFragment1();}
                if(ocu18.equals("")){
                    openFragment();
                }
            }
        });
    }

    public void AtualizarButton(){
       conexaoSQL = new ConexaoSQL();
       connection = conexaoSQL.connectionclass();
       Statement st = conexaoSQL.createStatement(connection);
       String con1, con2, con3, con4, con5, con6, con7, con8, con9, con10,
               con11, con12, con13, con14, con15, con16, con17, con18;

        con1 = "Select status_mesa From Mesa where numero_mesa = 1";
        try {ResultSet rs = st.executeQuery(con1);
            if (rs.next()) {String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa1.setBackgroundColor(Color.RED);ocu1 = "ocupada";}else{ocu1 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con2 = "Select status_mesa From Mesa where numero_mesa = 2";
        try {ResultSet rs = st.executeQuery(con2);
            if (rs.next()){String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa2.setBackgroundColor(Color.RED);ocu2 = "ocupada";}else{ocu2 = "";}}} catch (SQLException e) {throw new RuntimeException(e);}

        con3 = "Select status_mesa From Mesa where numero_mesa = 3";
        try {ResultSet rs = st.executeQuery(con3);
            if (rs.next()) {String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa3.setBackgroundColor(Color.RED);ocu3 = "ocupada";}else{ocu3 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con4 = "Select status_mesa From Mesa where numero_mesa = 4";
        try {ResultSet rs = st.executeQuery(con4);if (rs.next()){String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa4.setBackgroundColor(Color.RED);ocu4 = "ocupada";}else{ocu4 = "";}}} catch (SQLException e) {throw new RuntimeException(e);}

        con5 = "Select status_mesa From Mesa where numero_mesa = 5";
        try {ResultSet rs = st.executeQuery(con5);if (rs.next()) {String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa5.setBackgroundColor(Color.RED);ocu5 = "ocupada";}else{ocu5 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con6 = "Select status_mesa From Mesa where numero_mesa = 6";
        try {ResultSet rs = st.executeQuery(con6);if (rs.next()){String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa6.setBackgroundColor(Color.RED);ocu6 = "ocupada";}else{ocu6 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con7 = "Select status_mesa From Mesa where numero_mesa = 7";
        try {ResultSet rs = st.executeQuery(con7);
            if (rs.next()) {String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa7.setBackgroundColor(Color.RED);ocu7 = "ocupada";}else{ocu7 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con8 = "Select status_mesa From Mesa where numero_mesa = 8";
        try {ResultSet rs = st.executeQuery(con8);
            if (rs.next()){String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa8.setBackgroundColor(Color.RED);ocu8 = "ocupada";}else{ocu8 = "";}}} catch (SQLException e) {throw new RuntimeException(e);}

        con9 = "Select status_mesa From Mesa where numero_mesa = 9";
        try {ResultSet rs = st.executeQuery(con9);if (rs.next()) {String status = rs.getString(1);
            if("Ocupada".equals(status)){binding.mesa9.setBackgroundColor(Color.RED);ocu9 = "ocupada";}else{ocu9 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con10 = "Select status_mesa From Mesa where numero_mesa = 10";
        try {ResultSet rs = st.executeQuery(con10);if (rs.next()){String status = rs.getString(1);
            if("Ocupada".equals(status)){binding.mesa10.setBackgroundColor(Color.RED);ocu10 = "ocupada";}else{ocu10 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con11 = "Select status_mesa From Mesa where numero_mesa = 11";
        try {ResultSet rs = st.executeQuery(con11);
            if (rs.next()) {String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa11.setBackgroundColor(Color.RED);ocu11 = "ocupada";}else{ocu11 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con12 = "Select status_mesa From Mesa where numero_mesa = 12";
        try {ResultSet rs = st.executeQuery(con12);
            if (rs.next()){String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa12.setBackgroundColor(Color.RED);ocu12 = "ocupada";}else{ocu12 = "";}}} catch (SQLException e) {throw new RuntimeException(e);}

        con13 = "Select status_mesa From Mesa where numero_mesa = 13";
        try {ResultSet rs = st.executeQuery(con13);
            if (rs.next()) {String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa13.setBackgroundColor(Color.RED);ocu13 = "ocupada";}else{ocu13 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con14 = "Select status_mesa From Mesa where numero_mesa = 14";
        try {ResultSet rs = st.executeQuery(con14);
            if (rs.next()){String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa14.setBackgroundColor(Color.RED);ocu14 = "ocupada";}else{ocu14 = "";}}} catch (SQLException e) {throw new RuntimeException(e);}

        con15 = "Select status_mesa From Mesa where numero_mesa = 15";
        try {ResultSet rs = st.executeQuery(con15);if (rs.next()) {String status = rs.getString(1);
            if("Ocupada".equals(status)){binding.mesa15.setBackgroundColor(Color.RED);ocu15 = "ocupada";}else{ocu15 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con16 = "Select status_mesa From Mesa where numero_mesa = 16";
        try {ResultSet rs = st.executeQuery(con16);if (rs.next()){String status = rs.getString(1);
            if("Ocupada".equals(status)){binding.mesa16.setBackgroundColor(Color.RED);ocu16 = "ocupada";}else{ocu16 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con17 = "Select status_mesa From Mesa where numero_mesa = 17";
        try {ResultSet rs = st.executeQuery(con17);
            if (rs.next()) {String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa17.setBackgroundColor(Color.RED);ocu17 = "ocupada";}else{ocu17 = "";}}}catch (SQLException e) {throw new RuntimeException(e);}

        con18 = "Select status_mesa From Mesa where numero_mesa = 18";
        try {ResultSet rs = st.executeQuery(con18);
            if (rs.next()){String status = rs.getString(1);
                if("Ocupada".equals(status)){binding.mesa18.setBackgroundColor(Color.RED);ocu18 = "ocupada";}else{ocu18 = "";}}} catch (SQLException e) {throw new RuntimeException(e);}
    }
    private void openFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame, new TelaMesaFragment());
        fragmentTransaction.commit();
    }
    private void openFragment1() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame, new TelaMesaOcupadaFragment());
        fragmentTransaction.commit();
    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}