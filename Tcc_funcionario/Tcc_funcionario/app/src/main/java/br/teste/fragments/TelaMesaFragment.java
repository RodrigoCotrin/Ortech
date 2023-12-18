package br.teste.fragments;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import br.teste.classes.ImageConverterToBD;
import br.teste.classes.ProductMesa;
import br.teste.R;
import br.teste.databinding.FragmentTelaMesaBinding;

public class TelaMesaFragment extends Fragment {

    FragmentTelaMesaBinding binding;
    ProductMesa productMesa;
    int clicado;
    public TelaMesaFragment() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentTelaMesaBinding.inflate(inflater, container, false);
        View view = binding.getRoot();
        clicado = 0;
        productMesa = new ProductMesa();
        //ImageConverterToBD.insertImageIntoDatabase(getContext(), R.drawable.logo);
        binding.numeroMesa.setText("Mesa "+ productMesa.getNum_mesa());

        return view;
    }
    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.voltar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {openChildFragment();}
        });
        binding.pedidosAnteriores.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
               openChildFragment1();
            }
        });
        binding.verificarReserva.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                productMesa.setNum_mesa1(Integer.parseInt(productMesa.getNum_mesa()));
                productMesa.setClique(1);
                openChildFragment2();
            }
        });
        binding.realizarPedido.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openChildFragment3();
            }
        });
    }
    private void openChildFragment() {
            FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.fram1, new MesasFragment());
            fragmentTransaction.addToBackStack(null);
            fragmentTransaction.commit();
    }
     private void openChildFragment1() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram1, new HistoricoDePedidosFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
     }
    private void openChildFragment2() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram1, new TelaReservasFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
    private void openChildFragment3() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram1, new CarrinhoFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}