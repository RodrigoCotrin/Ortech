package br.teste.fragments;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.renderscript.ScriptGroup;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import br.teste.R;
import br.teste.classes.AbreProdutos;
import br.teste.classes.ProductMesa;
import br.teste.databinding.FragmentTelaPratoBinding;

public class TelaPratoFragment extends Fragment {

    FragmentTelaPratoBinding binding;
    public TelaPratoFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentTelaPratoBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        binding.nome.setText(AbreProdutos.getNome());

        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);


    }
}