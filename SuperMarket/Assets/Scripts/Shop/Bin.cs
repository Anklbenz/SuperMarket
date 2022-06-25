public class Bin : Shop
{
    public override bool CanPut => true;

    public Bin(){
        Store = new StoreBin();
    }
}
