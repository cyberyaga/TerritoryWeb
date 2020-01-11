using DbLocalizationProvider;
namespace Resources.Views.Doors
{
    [LocalizedResource]
    public class Index
    {
        public static string AddDoorBtn => "Add Door";
        public static string CurrentTerritory => "Current Territory";
        public static string DeleteModalDescription => "Are you sure you want to delete Door";
        public static string DeleteModalTitle => "Delete Door";
        public static string GeoCodeError1 => "This address is outside the boundaries of the territory";
        public static string GeoCodeError2 => "Unable to determine address location. Geolocation invalid";
        public static string GeoCodeError3 => "Unable to find address. Reason";
        public static string GeoCodeError4 => "Try Adding more info";
        public static string GeoCodeMsg1 => "Address Found";
        public static string IndicatorMessage => "Red highlights indicate that the address is outside of the territory bounds";
        public static string MapTitle => "Map View";
        public static string ModifyModalChangeSavedErrMsg => "Error Saving Changes";
        public static string ModifyModalChangeSavedMsg => "Changes saved";
        public static string ModifyModalDeleteDoorBtn => "Delete Door";
        public static string ModifyModalNextBtn => "Next";
        public static string ModifyModalPreviousBtn => "Previous";
        public static string ModifyModalSaveChanges => "Save Changes";
        public static string ModifyModalShowMapBtn => "Show Address on Map";
        public static string ModifyModalTitle => "Modify Address Information";
        public static string ProximitySortBtn => "Proximity Sort";
        public static string ProximitySortBtnTitle => "Order doors by how close they are on the map";
        public static string TerritoryDetailsBtn => "Territory Details";
  
    }
}
