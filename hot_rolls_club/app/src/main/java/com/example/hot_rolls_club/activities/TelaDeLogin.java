package com.example.hot_rolls_club.activities;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.InputType;
import android.util.Log;
import android.view.View;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.classes.Cliente;
import com.example.hot_rolls_club.classes.ConexaoSQL;
import com.example.hot_rolls_club.classes.ContaCli;
import com.example.hot_rolls_club.databinding.ActivityTelaDeCadastroBinding;
import com.example.hot_rolls_club.databinding.ActivityTelaDeLoginBinding;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;

public class TelaDeLogin extends AppCompatActivity {

    ActivityTelaDeLoginBinding binding;
    Cliente cl = new Cliente();

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityTelaDeLoginBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());


    binding.btnEntrar.setOnClickListener(new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            ConexaoSQL conexaoSQL = new ConexaoSQL();
            Connection connection = conexaoSQL.connectionclass();

            if (connection != null) {
                try {
                    String email = binding.txtEmail.getText().toString();
                    String senha = binding.txtSenha.getText().toString();

                    cl.setEmail(email);

                    // Chame a procedure usp_loginCliente
                    String sqlCallProcedure = "{ call usp_loginCliente (?, ?) }";

                    CallableStatement callableStatement = connection.prepareCall(sqlCallProcedure);
                    callableStatement.setString(1, email);
                    callableStatement.setString(2, senha);

                    ResultSet resultSet = callableStatement.executeQuery();

                    if (resultSet.next()) {
                        String loginResult = resultSet.getString(1);

                        if (loginResult.equals("Login aceito")) {
                            ContaCli.setEmailCli(email);
                            ContaCli.obter();
                            Intent intent = new Intent(TelaDeLogin.this, MainActivity.class);
                            startActivity(intent);
                        } else if (loginResult.equals("Login recusado")) {
                            binding.txtMenssagem.setText("Usuário ou senha incorretos");
                        } else {
                            binding.txtMenssagem.setText("Email ou senha inválidos");
                        }
                    }

                    callableStatement.close();

                } catch (Exception exception) {
                    Log.e("Error", exception.getMessage());
                } finally {
                    conexaoSQL.closeConnection(connection);
                }
            }
        }
    });

    //binding.txtEmail.setText("maria.silva@gmail.com");
    //binding.txtSenha.setText("12345678");
        binding.txtEmail.setText("luiz.ricardo@gmail.com");
        binding.txtSenha.setText("luizricardo007");



        binding.btnNaoTemConta.setOnClickListener(new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Intent intent = new Intent(TelaDeLogin.this, TelaDeCadastro.class);
            startActivity(intent);
        }
    });
        binding.btnSenhaVisivel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                toggleVisibility();
            }
        });
    }
    private void toggleVisibility() {
        int inputType = binding.txtSenha.getInputType();

        if (inputType == InputType.TYPE_TEXT_VARIATION_VISIBLE_PASSWORD)
        {
            binding.txtSenha.setInputType(InputType.TYPE_CLASS_TEXT | InputType.TYPE_TEXT_VARIATION_PASSWORD);
        }
        else {binding.txtSenha.setInputType(InputType.TYPE_TEXT_VARIATION_VISIBLE_PASSWORD);}

        binding.txtSenha.setSelection(binding.txtSenha.getText().length());
    }
}
