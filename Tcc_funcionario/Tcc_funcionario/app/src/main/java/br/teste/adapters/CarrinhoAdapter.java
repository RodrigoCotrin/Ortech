package br.teste.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;
import java.util.List;
import br.teste.R;
import br.teste.classes.Carrinho;

public class CarrinhoAdapter extends BaseAdapter {
    private List<Carrinho> carrinho;
    private Context context;

    public CarrinhoAdapter(Context context, List<Carrinho> carrinho) {
        this.context = context;
        this.carrinho = carrinho;
    }

    @Override
    public int getCount() {
        return carrinho.size();
    }

    @Override
    public Object getItem(int position) {
        return carrinho.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        convertView = View.inflate(this.context, R.layout.adapter_carrinho, null);


        TextView nomeProduto = convertView.findViewById(R.id.nomeProduto);
        TextView qtde = convertView.findViewById(R.id.qtde);
        TextView valor = convertView.findViewById(R.id.valor);


        nomeProduto.setText(carrinho.get(position).getNomeProduto());
        qtde.setText(String.valueOf(carrinho.get(position).getQuantidade())); // Converte para String
        //valor.setText(String.valueOf("R$ " + carrinho.get(position).getValorqtde()));

        valor.setText(String.format("%.2f", carrinho.get(position).getValorqtde()));


        return convertView;
    }
    public void addItem(Carrinho item){
        this.carrinho.add(item);
        this.notifyDataSetChanged();
    }

    public void updateListViewHeight(ListView listView) {
        ListAdapter listAdapter = listView.getAdapter();
        if (listAdapter == null) {
            return;
        }

        int totalHeight = 0;
        for (int i = 0; i < listAdapter.getCount(); i++) {
            View listItem = listAdapter.getView(i, null, listView);
            listItem.measure(0, 0);
            totalHeight += listItem.getMeasuredHeight();
        }

        ViewGroup.LayoutParams params = listView.getLayoutParams();
        params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));
        listView.setLayoutParams(params);
        listView.requestLayout();
    }

    public boolean removerItem(int posicao, ListView listView){
        carrinho.remove(posicao);
        notifyDataSetChanged();
        updateListViewHeight(listView);
        return true;
    }
}