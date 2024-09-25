namespace CabinetLibrary
{
   public interface ILocalizable: ILocalPublisher
   {
      string OriginalPublisher { get; set; }
      string CountryOfLocalization { get; set; }

   }
}
