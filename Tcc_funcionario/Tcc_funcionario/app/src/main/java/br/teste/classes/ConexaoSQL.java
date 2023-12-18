package br.teste.classes;

import android.annotation.SuppressLint;
import android.os.StrictMode;
import android.util.Log;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class ConexaoSQL {
    @SuppressLint("NewApi")
    public Connection connectionclass() {

        Connection con = null;
        String ip = "192.168.0.134", port = "1433", username = "sa", password = "123456789", databasename = "hot_rolls_club";
        StrictMode.ThreadPolicy tp = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(tp);
        try {
            Class.forName("net.sourceforge.jtds.jdbc.Driver");
            String connectionUrl = "jdbc:jtds:sqlserver://" + ip + ":" + port + ";databasename=" + databasename + ";User=" + username + ";password=" + password + ";";
            con = DriverManager.getConnection(connectionUrl);
            Log.e("Deu certo", "Conectou");
        } catch (Exception exception) {
            Log.e("Error", exception.getMessage());
        }
        return con;
    }
    @SuppressLint("LongLogTag")
    public Statement createStatement(Connection connection) {
        try {
            return connection.createStatement();
        } catch (SQLException e) {
            Log.e("Error creating statement", e.getMessage());
            return null;
        }
    }
    @SuppressLint("LongLogTag")
    public void closeConnection(Connection connection) {
        try {
            if (connection != null) {
                connection.close();
            }
        } catch (SQLException e) {
            Log.e("Error closing connection", e.getMessage());
        }
    }
}

