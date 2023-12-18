package com.example.hot_rolls_club.activities;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.fragments.InicioFragment;

import java.util.Timer;
import java.util.TimerTask;

public class PedidoFeito extends AppCompatActivity {

    private final Timer timer = new Timer();
    TimerTask timerTask;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pedido_feito);
        timerTask = new TimerTask() {
            @Override
            public void run() {
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        gotoApresentacaoActivity();
                    }
                });
            }
        };
        timer.schedule(timerTask, 1500);
    }

    private void gotoApresentacaoActivity() {
        Intent intent = new Intent(getBaseContext(), MainActivity.class);
        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(intent);
        finish();
    }
}