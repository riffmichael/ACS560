using System;
					
namespace test
{

	public class Candy {
	int cValue;
	bool isChecked;
	int location;
		
		public Candy(){
		this.cValue=0;
		this.isChecked = false;
		this.location = 0;
		}
		
		public bool isClicked()  {
			return this.isChecked;			
		
		}
		public void setClicked() {
		this.isChecked = true;
		}
		public void setNotClicked() {
		this.isChecked = false;
		}
		public int showLocation() {
		return this.location;
		}
		public void setLocation(int loc) {
		this.location = loc;
		}
	
		public void setValue(int val) {
		this.cValue = val;
		}
		public int getValue() {
		return this.cValue;
		}
	
	

	
	
	public void Main()
	{
		Console.WriteLine("Hello World");
		
		int candysize = 64;
		
		Candy[] newCandy = new Candy[candysize];
		
		int[] values = new int[candysize];
		
		for (int i = 0; i < candysize; i++){
		
		newCandy[i] = new Candy();
		newCandy[i].setValue(i%4);
		}
		
		
		Console.WriteLine(newCandy[0].isClicked());
		newCandy[0].setClicked();
		Console.WriteLine(newCandy[0].isClicked());
		
		for (int i = 0; i < candysize; i++){
		
		Console.Write(newCandy[i].getValue()+" ");
		}
	
		
		
	
	}
	}
}
