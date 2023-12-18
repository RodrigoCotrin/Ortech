package br.teste.activitys;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.InputType;
import android.util.Log;
import android.view.View;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;

import br.teste.classes.ConexaoSQL;
import br.teste.classes.Id_Func;
import br.teste.databinding.ActivityTelaDeLoginBinding;

public class TelaDeLogin extends AppCompatActivity {

    ActivityTelaDeLoginBinding binding;
    Id_Func id_func = new Id_Func();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityTelaDeLoginBinding.inflate(getLayoutInflater());

        binding.txtEmailEntrar.setText("joao.souza@gmail.com");
        binding.txtSenhaEntrar.setText("12345678");

        setContentView(binding.getRoot());

        binding.visible.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                toggleVisibility();
            }
        });

        binding.btnEntrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ConexaoSQL conexaoSQL = new ConexaoSQL();
                Connection connection = conexaoSQL.connectionclass();

                if (connection != null) {
                    try {
                        String email = binding.txtEmailEntrar.getText().toString();
                        String senha = binding.txtSenhaEntrar.getText().toString();

                        // Chame a procedure usp_loginCliente
                        String sqlCallProcedure = "{ call usp_loginFunc (?, ?) }";

                        CallableStatement callableStatement = connection.prepareCall(sqlCallProcedure);
                        callableStatement.setString(1, email);
                        callableStatement.setString(2, senha);

                        ResultSet resultSet = callableStatement.executeQuery();

                        if (resultSet.next()) {
                            String loginResult = resultSet.getString(1);

                            if (loginResult.equals("Login aceito")) {
                                Id_Func.setEmailFunc(email);
                                Id_Func.obter();
                                Intent intent = new Intent(TelaDeLogin.this, MainActivity.class);
                                startActivity(intent);
                            } else if (loginResult.equals("Login recusado")) {
                                binding.lblResultado.setText("Usuário ou senha incorretos");
                            } else {
                                binding.lblResultado.setText("Email ou senha inválidos");
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
    }
    private void toggleVisibility() {
        int inputType = binding.txtSenhaEntrar.getInputType();

        if (inputType == InputType.TYPE_TEXT_VARIATION_VISIBLE_PASSWORD)
        {
            binding.txtSenhaEntrar.setInputType(InputType.TYPE_CLASS_TEXT | InputType.TYPE_TEXT_VARIATION_PASSWORD);
        }
        else {binding.txtSenhaEntrar.setInputType(InputType.TYPE_TEXT_VARIATION_VISIBLE_PASSWORD);}

        binding.txtSenhaEntrar.setSelection(binding.txtSenhaEntrar.getText().length());
    }
}