package br.teste.classes;
public class ProductMesa {
    private static String num_mesa;
    private static int num_mesa1, clique;
    public static int getClique() {return clique;}
    public static void setClique(int clique) {ProductMesa.clique = clique;}
    public String getNum_mesa() {
        return num_mesa;
    }
    public void setNum_mesa(String num_mesa) {
        this.num_mesa = num_mesa;
    }
    public static void setNum_mesa1(int num_mesa1) {ProductMesa.num_mesa1 = num_mesa1;}
    public static int getNum_mesa1() {
        return num_mesa1;
    }
}
