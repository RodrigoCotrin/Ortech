package com.example.hot_rolls_club.fragments;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.databinding.FragmentCardapioBinding;
import com.example.hot_rolls_club.databinding.FragmentVerFormasPagamentoBinding;

public class VerFormasPagFragment extends Fragment {

    FragmentVerFormasPagamentoBinding binding;

    public VerFormasPagFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentVerFormasPagamentoBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.btnAdicionarPagamento.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
            openChildFragment();
            }
        });
    }
    private void openChildFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.frame102, new CadastrarCartaoFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
}