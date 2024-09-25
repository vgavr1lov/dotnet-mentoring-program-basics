namespace EFHomeTaskLibrary
{
   public interface IProduct
   {
      int Id { get; set; }
      string Description { get; set; }
      decimal Height { get; set; }
      decimal Length { get; set; }
      decimal Weight { get; set; }
      decimal Width { get; set; }
   }
}