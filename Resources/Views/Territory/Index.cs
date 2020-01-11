using DbLocalizationProvider;
namespace Resources.Views.Territory
{
    [LocalizedResource]
    public class Index
    {
        public static string TerritoryPageTitle => "Territories";
        public static string DoorCount => "Doors";
        public static string ModalDeleteTitle => "Delete Territory";
        public static string ModalBodyMsg1 => "Are you sure you want to delete territory:";
        public static string ModalBodyMsg2 => "Note: This will delete all doors associated with this territory.";
        public static string DoorLinkTitle => "Click here to view door list.";
        public static string NewTerritoryButton => "Create New Territory";
        public static string TerritoryLinkTitle => "Click here to view territory details.";
        public static string ViewTerritoriesButton => "View Territories";
    }
}