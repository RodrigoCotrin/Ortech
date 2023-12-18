package br.teste.fragments;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;

import br.teste.classes.ConexaoSQL;
import br.teste.classes.Id_Func;
import br.teste.R;
import br.teste.databinding.FragmentInformacoesFuncBinding;

public class InformacoesFuncFragment extends Fragment {

    FragmentInformacoesFuncBinding binding;
    Id_Func id_func = new Id_Func();
    String email, endereco, senha, telefone;
    ConexaoSQL conexaoSQL;
    Connection connection;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentInformacoesFuncBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        binding.identificacao.setText(Id_Func.getIdFunc());
        binding.txtNome.setText(Id_Func.getNomeFunc());
        binding.txtCPF.setText(Id_Func.getCpfFunc());
        binding.txtEmail.setText(Id_Func.getEmailFunc());
        binding.txtCargo.setText(Id_Func.getCargoFunc());
        binding.txtData.setText(Id_Func.getDataNasFunc());
        if(Id_Func.getSexoFunc().equals("M"))
        {binding.txtSexo.setText("Masculino");}
        else{binding.txtSexo.setText("Feminino");}
        binding.txtTelefone.setText(Id_Func.getTelefoneFunc());
        binding.txtEndereco.setText(Id_Func.getEnderecoFunc());
        binding.txtTurno.setText(Id_Func.getTurnoFunc());
        binding.txtSenha.setText(Id_Func.getSenhaFunc());
        binding.imgFunc.setImageBitmap(Id_Func.getImgFunc());

        senha = Id_Func.getSenhaFunc();
        endereco = Id_Func.getEnderecoFunc();
        telefone = Id_Func.getTelefoneFunc();
        email = Id_Func.getEmailFunc();


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
        binding.changeEndereco.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                binding.txtEndereco.setEnabled(true);
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
                    String update = "UPDATE Funcionario SET senha = '";
                    conexaoSQL = new ConexaoSQL();
                    connection = conexaoSQL.connectionclass();
                    Statement st = conexaoSQL.createStatement(connection);
                    try
                    {
                          int rs = st.executeUpdate(update + binding.txtSenha.getText() + "' WHERE id_funcionario = " + Id_Func.getIdFunc());
                          if(rs>0){
                              binding.txtSenha.setEnabled(false);
                              binding.salvarAlteraOes.setVisibility(View.INVISIBLE);
                              verifica++;
                    }} catch (SQLException e) {throw new RuntimeException(e);}
                }
                if(!email.equals(binding.txtEmail.getText())){
                    String update = "UPDATE Funcionario SET email = '";
                    conexaoSQL = new ConexaoSQL();
                    connection = conexaoSQL.connectionclass();
                    Statement st = conexaoSQL.createStatement(connection);
                    try
                    {
                        int rs = st.executeUpdate(update + binding.txtEmail.getText() + "' WHERE id_funcionario = " + Id_Func.getIdFunc());
                        if(rs>0){
                            binding.txtEmail.setEnabled(false);
                            binding.salvarAlteraOes.setVisibility(View.INVISIBLE);
                           verifica++;
                    }} catch (SQLException e) {throw new RuntimeException(e);}
                }
                if(!endereco.equals(binding.txtEndereco.getText())){
                    String update = "UPDATE Funcionario SET endereco = '";
                    conexaoSQL = new ConexaoSQL();
                    connection = conexaoSQL.connectionclass();
                    Statement st = conexaoSQL.createStatement(connection);
                    try
                    {
                        int linhas = st.executeUpdate(update + binding.txtEndereco.getText() + "'");
                        if(linhas>0){
                            binding.txtEndereco.setEnabled(false);
                            binding.salvarAlteraOes.setVisibility(View.INVISIBLE);
                            verifica++;
                    }} catch (SQLException e) {throw new RuntimeException(e);}
                }
                if(!telefone.equals(binding.txtTelefone.getText())){
                    String update = "UPDATE Funcionario SET telefone = '";
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
        fragmentTransaction.replace(R.id.frame, new PerfilFragment());
        fragmentTransaction.commit();
    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}