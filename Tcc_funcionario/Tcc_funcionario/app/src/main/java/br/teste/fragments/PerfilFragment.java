package br.teste.fragments;

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

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

import br.teste.classes.Id_Func;
import br.teste.R;
import br.teste.activitys.TelaDeLogin;
import br.teste.databinding.FragmentPerfilBinding;

public class PerfilFragment extends Fragment {

    FragmentPerfilBinding binding;
    Id_Func id_func = new Id_Func();

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

        String dataString = Id_Func.getContrataçãoFunc(); // Formato: "yyyy-MM-dd"
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
        try {
            // Converta a string em um objeto Date
            Date dataInformada = dateFormat.parse(dataString);
            // Obtenha a data atual
            Date dataAtual = new Date();
            // Crie objetos Calendar para manipular as datas
            Calendar calendarInformada = Calendar.getInstance();
            Calendar calendarAtual = Calendar.getInstance();
            // Defina as datas nos objetos Calendar
            calendarInformada.setTime(dataInformada);
            calendarAtual.setTime(dataAtual);
            // Calcule a diferença em milissegundos
            long diferencaEmMillis = calendarAtual.getTimeInMillis() - calendarInformada.getTimeInMillis();
            // Converta a diferença em dias
            long diasPassados = diferencaEmMillis / (24 * 60 * 60 * 1000);

            binding.numEquipe.setText(diasPassados + " dias");
        } catch (ParseException e) {e.printStackTrace();}
        Id_Func.obter1();

        binding.nomeFunc.setText(Id_Func.getNomeFunc());
        binding.nomeCargo.setText(Id_Func.getCargoFunc());
        binding.numPed.setText(Id_Func.getMesasFunc());
        binding.imgFunc.setImageBitmap(Id_Func.getImgFunc());

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
                //Intent it = new Intent(getContext(), TelaDeLogin.class);
                //startActivity(it);
                mostrarDialogoConfirmacaoSaida();
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
        fragmentTransaction.replace(R.id.frame, new InformacoesFuncFragment());
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