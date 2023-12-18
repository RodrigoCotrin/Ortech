package com.example.hot_rolls_club.fragments;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.activities.TelaDeLogin;
import com.example.hot_rolls_club.classes.ContaCli;
import com.example.hot_rolls_club.databinding.FragmentPerfilBinding;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

public class PerfilFragment extends Fragment {

    FragmentPerfilBinding binding;
    ContaCli contaCli = new ContaCli();

    public PerfilFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentPerfilBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        binding.nomeCli.setText(ContaCli.getNomeCli());
        //binding.imgFunc.setImageBitmap(contaCli.getImgCli());

        return view;
    }
    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.perfil.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openFragment();
            }
        });

        binding.logout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                mostrarDialogoConfirmacaoSaida();
            }
        });
        binding.favoritos.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openFragmentFavoritos();
            }
        });
        binding.formaPagamento.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openFragmentVerFormasPag();
            }
        });
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    private void openFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame3, new InformacoesCliFragment());
        fragmentTransaction.commit();
    }

    private void openFragmentFavoritos() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame3, new FavoritosFragment());
        fragmentTransaction.commit();
    }

    private void openFragmentVerFormasPag() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame3, new VerFormasPagFragment());
        fragmentTransaction.commit();
    }

    private void mostrarDialogoConfirmacaoSaida() {
        AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
        builder.setTitle("Confirmar saída");
        builder.setMessage("Deseja realmente fazer logout?");
        builder.setPositiveButton("Sim", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                // Ação a ser executada ao confirmar a saída (por exemplo, finalizar o aplicativo)
                getActivity().finish();
            }
        });
        builder.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                // Ação a ser executada ao cancelar a saída (nada a fazer neste caso)
            }
        });
        AlertDialog dialog = builder.create();
        dialog.show();
    }
}