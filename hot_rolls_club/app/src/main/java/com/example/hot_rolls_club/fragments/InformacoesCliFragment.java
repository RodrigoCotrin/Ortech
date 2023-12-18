package com.example.hot_rolls_club.fragments;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.classes.ConexaoSQL;
import com.example.hot_rolls_club.classes.ContaCli;
import com.example.hot_rolls_club.databinding.FragmentInformacoesCliBinding;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;

public class InformacoesCliFragment extends Fragment {

    FragmentInformacoesCliBinding binding;
    ContaCli contaCli = new ContaCli();
    String email, senha, telefone;
    ConexaoSQL conexaoSQL;
    Connection connection;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentInformacoesCliBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        binding.txtNome.setText(contaCli.getNomeCli());
        binding.txtCPF.setText(contaCli.getCpf());
        binding.txtEmail.setText(contaCli.getEmailCli());
        binding.txtData.setText(contaCli.getDataCli());
        if(contaCli.getSexoCli().equals("M"))
        {binding.txtSexo.setText("Masculino");}
        else{binding.txtSexo.setText("Feminino");}
        binding.txtTelefone.setText(contaCli.getTelefoneCli());
        //binding.imgFunc.setImageBitmap(contaCli.getImgCli());

        binding.txtSenha.setText(contaCli.getSenhaCli());
        telefone = contaCli.getTelefoneCli();
        email = contaCli.getEmailCli();
        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.voltar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openFragment();
            }
        });

        binding.changeEmail.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                binding.txtEmail.setEnabled(true);
                binding.salvarAlteraOes.setVisibility(View.VISIBLE);
            }
        });
        binding.changeTelefone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                binding.txtTelefone.setEnabled(true);
                binding.salvarAlteraOes.setVisibility(View.VISIBLE);
            }
        });
        binding.changeSenha.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                binding.txtSenha.setEnabled(true);
                binding.salvarAlteraOes.setVisibility(View.VISIBLE);
            }
        });
        binding.salvarAlteraOes.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                int verifica = 0;

                if(!senha.equals(binding.txtSenha.getText())){
                    String update = "UPDATE Cliente SET senha = '";
                    conexaoSQL = new ConexaoSQL();
                    connection = conexaoSQL.connectionclass();
                    Statement st = conexaoSQL.createStatement(connection);
                    try
                    {
                        int rs = st.executeUpdate(update + binding.txtSenha.getText() + "' WHERE cpf = " + contaCli.getCpf());
                        if(rs>0){
                            binding.txtSenha.setEnabled(false);
                            binding.salvarAlteraOes.setVisibility(View.INVISIBLE);
                            verifica++;
                        }} catch (SQLException e) {throw new RuntimeException(e);}
                }
                if(!email.equals(binding.txtEmail.getText())){
                    String update = "UPDATE Cliente SET email = '";
                    conexaoSQL = new ConexaoSQL();
                    connection = conexaoSQL.connectionclass();
                    Statement st = conexaoSQL.createStatement(connection);
                    try
                    {
                        int rs = st.executeUpdate(update + binding.txtEmail.getText() + "' WHERE cpf = " + contaCli.getCpf());
                        if(rs>0){
                            binding.txtEmail.setEnabled(false);
                            binding.salvarAlteraOes.setVisibility(View.INVISIBLE);
                            verifica++;
                        }} catch (SQLException e) {throw new RuntimeException(e);}
                }
                if(!telefone.equals(binding.txtTelefone.getText())){
                    String update = "UPDATE Cliente SET telefone = '";
                    conexaoSQL = new ConexaoSQL();
                    connection = conexaoSQL.connectionclass();
                    Statement st = conexaoSQL.createStatement(connection);
                    try
                    {
                        int linhas = st.executeUpdate(update + binding.txtTelefone.getText() +"'");
                        if(linhas>0){
                            binding.txtTelefone.setEnabled(false);
                            binding.salvarAlteraOes.setVisibility(View.INVISIBLE);
                            verifica++;
                        }} catch (SQLException e) {throw new RuntimeException(e);}
                }
                if(verifica>0){
                    Toast.makeText(getContext(), "Alterações Realizadas com sucesso", Toast.LENGTH_LONG).show();
                }
            }
        });
    }

    private void openFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame4, new PerfilFragment());
        fragmentTransaction.commit();
    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}