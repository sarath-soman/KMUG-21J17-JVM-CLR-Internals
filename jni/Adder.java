public class Adder {
	
	static {		
		System.loadLibrary("adder");
	}

	public static void main(String[] args){		
		Adder adder = new Adder();
		int sum = adder.add(10, 20);
		System.out.println(sum);
	}

	public native int add(int x, int y);
}

