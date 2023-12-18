package com.example.hot_rolls_club.activities;

import static android.widget.Toast.LENGTH_SHORT;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.InputType;
import android.util.Log;
import android.view.View;
import android.widget.Toast;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.classes.ConexaoSQL;
import com.example.hot_rolls_club.databinding.ActivityTelaDeApresentacaoBinding;
import com.example.hot_rolls_club.databinding.ActivityTelaDeCadastroBinding;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;

public class TelaDeCadastro extends AppCompatActivity {

    ActivityTelaDeCadastroBinding binding;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding= ActivityTelaDeCadastroBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        binding.btnCadastrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ConexaoSQL conexaoSQL = new ConexaoSQL();
                Connection connection = conexaoSQL.connectionclass();

                if (connection != null) {
                    try {
                        String cpf = binding.txtCpf.getText().toString();
                        String nomecompleto = binding.txtNomeCompleto.getText().toString();
                        String telefone = binding.txtTelefone.getText().toString();
                        String email = binding.txtEmail.getText().toString();
                        String senha = binding.txtSenha.getText().toString();

                        // Verifica se o email é válido (pode ser uma validação local simples)
                        if (isValidEmail(email)) {
                            // Chame a procedure usp_cadastrarCliente
                            String sqlCallProcedure = "{ call usp_cadastrarCliente(?, ?, ?, ?, ?) }";

                            CallableStatement callableStatement = connection.prepareCall(sqlCallProcedure);
                            callableStatement.setString(1, cpf);
                            callableStatement.setString(2, nomecompleto);
                            callableStatement.setString(3, telefone);
                            callableStatement.setString(4, email);
                            callableStatement.setString(5, senha);

                            ResultSet resultSet = callableStatement.executeQuery();

                            if (resultSet.next()) {
                                String resultMessage = resultSet.getString(1); // Supondo que o resultado é a primeira coluna

                                if (resultMessage.equals("Cadastro realizado com sucesso")) {
                                    Intent intent = new Intent(TelaDeCadastro.this, MainActivity.class);
                                    startActivity(intent);
                                } else {
                                    binding.txtEmail.setText(resultMessage);
                                }
                            }

                            callableStatement.close();
                        } else {
                            binding.txtEmail.setText("Email inválido");
                        }
                    } catch (Exception exception) {
                        Log.e("Error", exception.getMessage());
                    } finally {
                        conexaoSQL.closeConnection(connection);
                    }
                }
            }

            private boolean isValidEmail(String email) {
                String emailPattern = "[a-zA-Z0-9._-]+@[a-z]+\\.+[a-z]+";
                return email.matches(emailPattern);
            }
        });

        binding.btnJatemConta.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(TelaDeCadastro.this, TelaDeLogin.class);
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