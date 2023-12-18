package br.teste.activitys;

import static android.app.PendingIntent.getActivity;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.MenuItem;

import com.google.android.material.navigation.NavigationBarView;

import br.teste.R;
import br.teste.databinding.ActivityMainBinding;
import br.teste.fragments.CardapioFragment;
import br.teste.fragments.MesasFragment;
import br.teste.fragments.PerfilFragment;
import br.teste.fragments.ReservaFragment;

public class MainActivity extends AppCompatActivity {

    ActivityMainBinding binding;
    FragmentManager fragmentManager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        binding.bottomnavigation.setOnItemSelectedListener(new NavigationBarView.OnItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                int itemId = item.getItemId();
                if(itemId == R.id.menu_mesas){
                    openFragment(new MesasFragment());
                    return true;
                } else if(itemId == R.id.menu_reservas){
                    openFragment(new ReservaFragment());
                    return true;
                } else if(itemId == R.id.menu_perfil){
                    openFragment(new PerfilFragment());
                    return true;
                }else if(itemId == R.id.menu_cardapio){
                    openFragment(new CardapioFragment());
                    return true;
                }
                return true;
            }
        });
        fragmentManager = getSupportFragmentManager();
               openFragment(new MesasFragment());
    }
   private void openFragment(Fragment fragment){
        FragmentTransaction transaction = fragmentManager.beginTransaction();
        transaction.replace(R.id.frame_layout, fragment);
        transaction.commit();
    }

   private void mostrarDialogoConfirmacaoSaida() {
       AlertDialog.Builder builder = new AlertDialog.Builder(this);
       builder.setTitle("Confirmar saída");
       builder.setMessage("Deseja realmente sair do aplicativo?");
       builder.setPositiveButton("Sim", new DialogInterface.OnClickListener() {
           @Override
           public void onClick(DialogInterface dialog, int which) {
               finish(); // Encerra a MainActivity
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

    @Override
    public void onBackPressed() {
        mostrarDialogoConfirmacaoSaida();
    }
}