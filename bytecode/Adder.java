public class Adder {

    public int add(int x, int y) {
        return x + y;
    }

    public static void main(String[] args) {
        int sum = new Adder().add(10, 20);
        sum++;
        System.out.println(sum);
    }

}