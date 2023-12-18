package com.example.hot_rolls_club.fragments;

import android.os.Bundle;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.example.hot_rolls_club.classes.DadosCartao;
import com.example.hot_rolls_club.databinding.FragmentCadastrarCartaoBinding;

import java.util.regex.Pattern;

public class CadastrarCartaoFragment extends Fragment {

    FragmentCadastrarCartaoBinding binding;
    boolean primeiroCliqueNumeroCartao = true;

    public CadastrarCartaoFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentCadastrarCartaoBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.btnAdicionarPagamento.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (validarCampos()) {
                    adicionarPagamento();
                } else {
                    Toast.makeText(getContext(), "Por favor, preencha corretamente todos os campos do cartão", Toast.LENGTH_SHORT).show();
                }
            }
        });

        binding.editNumeroCartao.addTextChangedListener(new TextWatcher() {
            private boolean isFormatting;
            private boolean deletingHyphen;
            private int prevLength;

            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
                prevLength = binding.editNumeroCartao.getText().length();
                if (after < count) {
                    deletingHyphen = true;
                }
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
            }

            @Override
            public void afterTextChanged(Editable s) {
                if (!isFormatting) {
                    isFormatting = true;

                    int currentLength = s.length();
                    if (currentLength > prevLength) {
                        if (currentLength == 5 || currentLength == 10 || currentLength == 15) {
                            String formattedText = formatCardNumber(s.toString());
                            binding.editNumeroCartao.setText(formattedText);
                            binding.editNumeroCartao.setSelection(formattedText.length());
                        }
                    } else if (currentLength < prevLength) {
                        if (deletingHyphen) {
                            deletingHyphen = false;
                            s.delete(s.length() - 1, s.length());
                        }
                    }
                    isFormatting = false;
                }
            }
        });

        binding.editMesAno.addTextChangedListener(new TextWatcher() {
            private boolean isFormatting;
            private boolean deletingSlash;
            private int prevLength;

            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
                prevLength = binding.editMesAno.getText().length();
                if (after < count) {
                    deletingSlash = true;
                }
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
            }

            @Override
            public void afterTextChanged(Editable s) {
                if (!isFormatting) {
                    isFormatting = true;

                    int currentLength = s.length();
                    if (currentLength > prevLength) {
                        if (currentLength == 2) {
                            if (!s.toString().contains("/")) {
                                binding.editMesAno.setText(formatMesAno(s.toString()));
                                binding.editMesAno.setSelection(binding.editMesAno.getText().length());
                            }
                        }
                    } else if (currentLength < prevLength) {
                        if (deletingSlash) {
                            deletingSlash = false;
                            s.delete(s.length() - 1, s.length());
                        }
                    }
                    isFormatting = false;
                }
            }
        });
    }

    private String formatCardNumber(String cardNumber) {
        cardNumber = cardNumber.replaceAll("\\s+", "");
        StringBuilder formatted = new StringBuilder();
        int groupSize = 4;
        for (int i = 0; i < cardNumber.length(); i++) {
            if (i > 0 && i % groupSize == 0) {
                formatted.append(" ");
            }
            formatted.append(cardNumber.charAt(i));
        }
        return formatted.toString();
    }

    private void adicionarPagamento() {
        String numeroCartao = binding.editNumeroCartao.getText().toString().replaceAll("\\s+", "");
        String mesAno = binding.editMesAno.getText().toString().trim();
        String cvv = binding.editCVV.getText().toString().trim();

        DadosCartao dadosCartao = new DadosCartao(numeroCartao, mesAno, cvv);

        binding.editNumeroCartao.setText("");
        binding.editMesAno.setText("");
        binding.editCVV.setText("");

        Toast.makeText(getContext(), "Pagamento adicionado com sucesso!", Toast.LENGTH_SHORT).show();
    }
    private boolean validarCampos() {
        String numeroCartao = binding.editNumeroCartao.getText().toString().replaceAll("\\s+", "");
        String mesAno = binding.editMesAno.getText().toString().trim();
        String cvv = binding.editCVV.getText().toString().trim();

        return validarNumeroCartao(numeroCartao)
                && validarMesAno(mesAno)
                && validarCVV(cvv);
    }

    private boolean validarNumeroCartao(String numeroCartao) {
        return numeroCartao.length() == 16;
    }

    private boolean validarMesAno(String mesAno) {
        return Pattern.matches("\\d{2}/\\d{2}", mesAno);
    }

    private boolean validarCVV(String cvv) {
        return cvv.length() == 3;
    }

    private String formatMesAno(String mesAno) {
        if (mesAno.length() == 2 && !mesAno.contains("/")) {
            return mesAno + "/";
        }
        return mesAno;
    }
}
