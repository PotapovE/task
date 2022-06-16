package Java;

public class Program {

    public static void main(String[] args) {

        int n = 3,
            k = 2;
        Build(n, k);                

    }

    public static void Build(int n, int k){
        for (int i = 1; i < n; i++) {
            for (int j = i + 1; j < n + 1; j++) {
                System.out.print(i);
                System.out.println(j);
            }
        }
    }
}