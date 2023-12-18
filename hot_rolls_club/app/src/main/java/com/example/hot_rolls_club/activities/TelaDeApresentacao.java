package com.example.hot_rolls_club.activities;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageButton;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.databinding.ActivityTelaDeApresentacaoBinding;

import java.util.List;

public class TelaDeApresentacao extends AppCompatActivity {

    ActivityTelaDeApresentacaoBinding binding;

    @Override
    public void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    binding= ActivityTelaDeApresentacaoBinding.inflate(getLayoutInflater());
    setContentView(binding.getRoot());

        binding.btnEntrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(TelaDeApresentacao.this, TelaDeLogin.class);
                startActivity(intent);
            }
        });

        binding.btnCadastrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(TelaDeApresentacao.this, TelaDeCadastro.class);
                startActivity(intent);
            }
        });
    }
}