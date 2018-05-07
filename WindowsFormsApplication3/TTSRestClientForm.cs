using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace TTS_Tool_Hub
{
  public partial class TTSRestClientFrame : Form
  {
    
    #region PublicVariables
    public string[] lines = new string[]{"", "", ""};
    public string URLText;

    #region myFilesDictionary
    public Dictionary<string, string> myFileDictionary = new Dictionary<string, string>()
    {
      {"http://localhost:5601/APhA/Services/GetAlerts", "5601GetAlerts"},
      {"http://localhost:5601/APhA/Services/GetUnsentAlerts", "5601GetUnsentAlerts"},
      {"http://localhost:5601/APhA/Services/RaiseAlerts", "5601RaiseAlerts"},
      {"http://localhost:5601/APhA/Services/UpdateSent", "5601UpdateSent"},
      {"http://localhost:5602/APhA/Services/GetAlerts", "5602GetAlerts"},
      {"http://localhost:5602/APhA/Services/RelayAlerts", "5602RelayAlerts"},
      {"http://localhost:5831/APhA/Services/ControllerStatus", "5831ControllerStatus"},
      {"http://localhost:5831/APhA/Services/LatencyCorrection", "5831LatencyCorrection"},
      {"http://localhost:5831/APhA/Services/Predictions", "5831Predictions"},
      {"http://localhost:5831/APhA/Services/SubmitPredictions", "5831SubmitPredictions"},
      {"http://localhost:5831/APhA/Services/UpdateIntersectionType", "5831UpdateIntersectionType"},
      {"http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest", "5942GetConfidenceDBDataRequest"},
      {"http://localhost:5942/APhA/Services/GetControllerInputDataRequest", "5942GetControllerInputDataRequest"},
      {"http://localhost:5942/APhA/Services/GetCurrentVersionRequest", "5942GetCurrentVersionRequest"},
      {"http://localhost:5942/APhA/Services/GetLogicDBDataRequest", "5942GetLogicDBDataRequest"},
      {"http://localhost:5942/APhA/Services/GetPredictionsDBDataRequest", "5942GetPredictionsDBDataRequest"},
      {"http://localhost:5942/APhA/Services/GetQuarantineDataRequest", "5942GetQuarantineDataRequest"},
      {"http://localhost:5942/APhA/Services/GetRegionSCDBDataRequest", "5942GetRegionSCDBDataRequest"},
      {"http://localhost:5942/APhA/Services/GetRelevantPhasesDataRequest", "5942GetRelevantPhasesDataRequest"},
      {"http://localhost:5942/APhA/Services/GetStatusDBDataRequest", "5942GetStatusDBDataRequest"},
      {"http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest", "5942GetTimingPlanDBDataRequest"},
      {"http://localhost:6240/APhA/Services/FixedTimePlanImporter", "6240FixedTimePlanImporter"},
      {"http://localhost:6240/APhA/Services/FixedTimeStatusImporter", "6240FixedTimeStatusImporter"},
      {"http://localhost:6240/APhA/Services/LatestStatus", "6240LatestStatus"},
      {"http://localhost:6240/APhA/Services/LatestTimingPlan", "6240LatestTimingPlan"},
      {"http://localhost:6240/APhA/Services/LatestTimingPlanInfo", "6240LatestTimingPlanInfo"},
      {"http://localhost:6240/APhA/Services/Predictions", "6240Predictions"},
      {"http://localhost:6247/APhA/Services/ChangeCoverage", "6247ChangeCoverage"},
      {"http://localhost:6247/APhA/Services/ChangePassword", "6247ChangePassword"},
      {"http://localhost:6247/APhA/Services/ChangeRole", "6247ChangeRole"},
      {"http://localhost:6247/APhA/Services/CreateUser", "6247CreateUser"},
      {"http://localhost:6247/APhA/Services/DeleteAccount", "6247DeleteAccount"},
      {"http://localhost:6247/APhA/Services/GetUsers", "6247GetUsers"},
      {"http://localhost:6247/APhA/Services/GetUsersCoverage", "6247GetUsersCoverage"},
      {"http://localhost:6247/APhA/Services/Login", "6247Login"},
      {"http://localhost:6247/APhA/Services/RenewSession", "6247RenewSession"},
      {"http://localhost:6247/APhA/Services/ResetPassword", "6247ResetPassword"},
      {"http://localhost:6247/APhA/Services/VerifyEmail", "6247VerifyEmail"},
      {"http://localhost:6247/APhA/Services/VerifyResetPassword", "6247VerifyResetPassword"},
      {"http://localhost:6250/APhA/Services/CreateProtPermOverride", "6250CreateProtPermOverride"},
      {"http://localhost:6250/APhA/Services/CreateProtPermQuarantine", "6250CreateProtPermQuarantine"},
      {"http://localhost:6250/APhA/Services/DeleteProtPermOverride", "6250DeleteProtPermOverride"},
      {"http://localhost:6250/APhA/Services/DeleteProtPermQuarantine", "6250DeleteProtPermQuarantine"},
      {"http://localhost:6250/APhA/Services/ReadProtPermOverride", "6250ReadProtPermOverride"},
      {"http://localhost:6250/APhA/Services/ReadProtPermQuarantine", "6250ReadProtPermQuarantine"},
      {"http://localhost:6250/APhA/Services/TopologyCorrection", "6250TopologyCorrection"},
      {"http://localhost:6250/APhA/Services/UpdateProtPermOverride", "6250UpdateProtPermOverride"},
      {"http://localhost:6250/APhA/Services/UpdateProtPermQuarantine", "6250UpdateProtPermQuarantine"},
      {"http://localhost:6260/APhA/Services/LatestStatus", "6260LatestStatus"},
      {"http://localhost:6260/APhA/Services/LatestTimingPlan", "6260LatestTimingPlan"},
      {"http://localhost:6260/APhA/Services/LatestTimingPlanInfo", "6260LatestTimingPlanInfo"},
      {"http://localhost:6260/APhA/Services/RecentSwitchEvents", "6260RecentSwitchEvents"},
      {"http://localhost:6260/APhA/Services/StatusHistory", "6260StatusHistory"},
      {"http://localhost:6260/APhA/Services/StatusImporter", "6260StatusImporter"},
      {"http://localhost:6260/APhA/Services/TimingPlanImporter", "6260TimingPlanImporter"},
      {"http://localhost:6317/APhA/Services/Coverage", "6317Coverage"},
      {"http://localhost:6317/APhA/Services/CreateIntersections", "6317CreateIntersections"},
      {"http://localhost:6317/APhA/Services/CreateRegions", "6317CreateRegions"},
      {"http://localhost:6317/APhA/Services/DeleteIntersections", "6317DeleteIntersections"},
      {"http://localhost:6317/APhA/Services/DeleteIntersectionTopology", "6317DeleteIntersectionTopology"},
      {"http://localhost:6317/APhA/Services/DeleteRegions", "6317DeleteRegions"},
      {"http://localhost:6317/APhA/Services/IntersectionStatus", "6317IntersectionStatus"},
      {"http://localhost:6317/APhA/Services/IntersectionTopology", "6317IntersectionTopology"},
      {"http://localhost:6317/APhA/Services/NextIntersection", "6317NextIntersection"},
      {"http://localhost:6317/APhA/Services/PostD4", "6317PostD4"},
      {"http://localhost:6317/APhA/Services/PostTopologyJSON", "6317PostTopologyJSON"},
      {"http://localhost:6317/APhA/Services/ReadIntersections", "6317ReadIntersections"},
      {"http://localhost:6317/APhA/Services/Topology", "6317Topology"},
      {"http://localhost:6317/APhA/Services/TopologyDate", "6317TopologyDate"},
      {"http://localhost:6317/APhA/Services/UpdateIntersections", "6317UpdateIntersections"},
      {"http://localhost:6317/APhA/Services/UpdateIntersectionTopology", "6317UpdateIntersectionTopology"},
      {"http://localhost:6317/APhA/Services/UpdateIntersectionType", "6317UpdateIntersectionType"},
      {"http://localhost:6317/APhA/Services/UpdateRegions", "6317UpdateRegions"},
      {"http://localhost:6416/APhA/Services/GevasStatusImporter", "6416GevasStatusImporter"},
      {"http://localhost:6416/APhA/Services/LatestStatus", "6416LatestStatus"},
      {"http://localhost:6441/APhA/Services/SupplierMap", "6441SupplierMap"},
      {"http://localhost:6711/APhA/Services/CreateHosts", "6711CreateHosts"},
      {"http://localhost:6711/APhA/Services/CreateServerConnections", "6711CreateServerConnections"},
      {"http://localhost:6711/APhA/Services/CreateServerCoverage", "6711CreateServerCoverage"},
      {"http://localhost:6711/APhA/Services/DeleteHosts", "6711DeleteHosts"},
      {"http://localhost:6711/APhA/Services/DeleteServerConnections", "6711DeleteServerConnections"},
      {"http://localhost:6711/APhA/Services/GetIntersectionMap", "6711GetIntersectionMap"},
      {"http://localhost:6711/APhA/Services/IntersectionMap", "6711IntersectionMap"},
      {"http://localhost:6711/APhA/Services/ServerMap", "6711ServerMap"},
      {"http://localhost:6711/APhA/Services/UpdateCoverage", "6711UpdateCoverage"},
      {"http://localhost:6711/APhA/Services/UpdateHosts", "6711UpdateHosts"},
      {"http://localhost:6711/APhA/Services/UpdateServerConnections", "6711UpdateServerConnections"},
      {"http://localhost:6777/APhA/Services/ReadConfidence", "6777ReadConfidence"}
    };
    #endregion

    public string myFilePath = @"C:\PScripts\ConfiguredRuns\";
    public string[] ConfiguredRunsLines = new string[]{};
    //declare arrays to help determine geo placement of new controls
    public List<string> theGets = new List<string> { "http://localhost:6247/APhA/Services/CreateUser", "http://localhost:6247/APhA/Services/VerifyEmail", "http://localhost:6247/APhA/Services/ResetPassword", "http://localhost:6247/APhA/Services/VerifyResetPassword", "http://localhost:6247/APhA/Services/Login", "http://localhost:6247/APhA/Services/ChangePassword", "http://localhost:6247/APhA/Services/RenewSession", "http://localhost:6247/APhA/Services/ChangeRole", "http://localhost:6247/APhA/Services/ChangeCoverage", "http://localhost:6247/APhA/Services/GetUsers", "http://localhost:6247/APhA/Services/GetUsersCoverage", "http://localhost:6247/APhA/Services/DeleteAccount", "http://localhost:6711/APhA/Services/ServerMap", "http://localhost:6711/APhA/Services/UpdateServerCoverage", "http://localhost:6711/APhA/Services/DeleteServerCoverage", "http://localhost:6711/APhA/Services/IntersectionMap", "http://localhost:6441/APhA/Services/SupplierMap", "http://localhost:5601/APhA/Services/GetAlerts", "http://localhost:5601/APhA/Services/GetUnsentAlerts", "http://localhost:5602/APhA/Services/GetAlerts", "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology", "http://localhost:6317/APhA/Services/TopologyDate", "http://localhost:6317/APhA/Services/NextIntersection", "http://localhost:6317/APhA/Services/IntersectionStatus", "http://localhost:6250/APhA/Services/ReadProtPermQuarantine", "http://localhost:6250/APhA/Services/ReadProtPermOverride", "http://localhost:5942/APhA/Services/GetRegionSCDBDataRequest", "http://localhost:5942/APhA/Services/GetStatusDBDataRequest", "http://localhost:5942/APhA/Services/GetPredictionsDBDataRequest", "http://localhost:5942/APhA/Services/GetControllerInputDataRequest", "http://localhost:5942/APhA/Services/GetLogicDBDataRequest", "http://localhost:5942/APhA/Services/GetQuarantineDataRequest", "http://localhost:5942/APhA/Services/GetCurrentVersionRequest", "http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest", "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest", "http://localhost:5942/APhA/Services/GetRelevantPhasesDataRequest", "http://localhost:6240/APhA/Services/LatestStatus", "http://localhost:6240/APhA/Services/Predictions", "http://localhost:6240/APhA/Services/LatestTimingPlan", "http://localhost:6240/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/LatestStatus", "http://localhost:6260/APhA/Services/LatestTimingPlan", "http://localhost:6260/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/RecentSwitchEvents", "http://localhost:6260/APhA/Services/StatusHistory", "http://localhost:6416/APhA/Services/LatestStatus", "http://localhost:5831/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/LatencyCorrection", "http://localhost:5831/APhA/Services/ControllerStatus" };
    public List<string> thePosts = new List<string> { "http://localhost:6711/APhA/Services/UpdateCoverage", "http://localhost:6711/APhA/Services/CreateHosts", "http://localhost:6711/APhA/Services/UpdateHosts", "http://localhost:6711/APhA/Services/DeleteHosts", "http://localhost:6711/APhA/Services/CreateServerCoverage", "http://localhost:6711/APhA/Services/CreateServerConnections", "http://localhost:6711/APhA/Services/UpdateServerConnections", "http://localhost:6711/APhA/Services/DeleteServerConnections", "http://localhost:6711/APhA/Services/GetIntersectionMap", "http://localhost:5601/APhA/Services/RaiseAlerts", "http://localhost:5601/APhA/Services/UpdateSent", "http://localhost:5602/APhA/Services/RelayAlerts", "http://localhost:6317/APhA/Services/IntersectionTopology", "http://localhost:6317/APhA/Services/CreateIntersections", "http://localhost:6317/APhA/Services/UpdateIntersections", "http://localhost:6317/APhA/Services/DeleteIntersections", "http://localhost:6317/APhA/Services/CreateRegions", "http://localhost:6317/APhA/Services/UpdateRegions", "http://localhost:6317/APhA/Services/DeleteRegions", "http://localhost:6317/APhA/Services/UpdateIntersectionTopology", "http://localhost:6317/APhA/Services/DeleteIntersectionTopology", "http://localhost:6317/APhA/Services/ReadIntersections", "http://localhost:6317/APhA/Services/PostTopologyJSON", "http://localhost:6317/APhA/Services/PostD4", "http://localhost:6317/APhA/Services/UpdateIntersectionType", "http://localhost:6250/APhA/Services/TopologyCorrection", "http://localhost:6250/APhA/Services/CreateProtPermQuarantine", "http://localhost:6250/APhA/Services/UpdateProtPermQuarantine", "http://localhost:6250/APhA/Services/DeleteProtPermQuarantine", "http://localhost:6250/APhA/Services/CreateProtPermOverride", "http://localhost:6250/APhA/Services/UpdateProtPermOverride", "http://localhost:6250/APhA/Services/DeleteProtPermOverride", "http://localhost:6240/APhA/Services/FixedTimeStatusImporter", "http://localhost:6240/APhA/Services/FixedTimePlanImporter", "http://localhost:6260/APhA/Services/StatusImporter", "http://localhost:6260/APhA/Services/TimingPlanImporter", "http://localhost:6416/APhA/Services/GevasStatusImporter", "http://localhost:5831/APhA/Services/UpdateIntersectionType", "http://localhost:5831/APhA/Services/SubmitPredictions", "http://localhost:6777/APhA/Services/ReadConfidence" };
    public List<string> myLabels = new List<string> { "returnjson", "sessioncode", "oldpassword", "newpassword", "username", "password", "emailaddress", "verificationcode", "recipientusername", "newrole", "addedcoverage", "revokedcoverage", "includecoverage", "targetusername", "limittouser", "targets", "method", "maxresults", "targetassignment", "filtertype", "intersectiontype", "latitude", "longitude", "region", "usegroups", "groupbysignal", "usequarantine", "scnr", "verificationstatus", "maxdistance", "heading", "targetdate", "tabletype", "targetstartdate", "targetenddate", "livetiminginfo", "groupnr", "includepredictions", "includezeroconfidencepredictions", "includetopology", "adjustforlatency", "horizon", "responseformat", "sourceusername", "fromtime", "totime", "encodedata", "group", "latencycorrection", "ClientAddress", "Updates", "Hosts", "IDs", "Server", "Keys", "Connections", "ReturnJSON", "alerts", "ipAddress", "Regions", "Path", "LiveGroups", "RegionNames", "D4File", "FixedTime", "Actuated", "FreeRunning", "Approach", "Version", "RegionID", "TSPackage", "Credentials", "Data", "Date", "Mode", "Horizons", "Hours", "Span", "TestPassesIfContains" };
    public List<Control> myControlInputBoxPlacement = new List<Control>();
    public List<Control> myControlInputLabelPlacement = new List<Control>();
    public List<TextBox> myUsedControlBoxes = new List<TextBox>();
    public List<Label> myUsedControlLabels = new List<Label>();
    public List<string> myUsedURLHeaders = new List<string>();
    public string httpWebRequestURLSent;
    public NameValueCollection postData = new NameValueCollection();
    #endregion

    #region SupportingFunctions
    public string userSelectedFilePath
    {
      get
      {
        return tbFilePath.Text;
      }
      set 
      {
        tbFilePath.Text = value;      
      }
    }

    private void LoadNewFile()
    {
      OpenFileDialog myOpenFile = new OpenFileDialog();
      myOpenFile.InitialDirectory = @"C:\PScripts\ConfiguredRuns";
      myOpenFile.Title = "RunRequest Config File";
      myOpenFile.CustomPlaces.Add(@"C:\PScripts\ConfiguredRuns");
      myOpenFile.Multiselect = false;
      myOpenFile.Filter = "ConfiguredRuns|*.txt;";
      System.Windows.Forms.DialogResult dr = myOpenFile.ShowDialog();
      if (dr == DialogResult.OK) {
        userSelectedFilePath = myOpenFile.FileName;
      }
    }

    public static void SessionCode(string[] src)
    {
      try {
        string URL = "http://localhost:6247/APhA/Services/Login?username=" + src[0] + "&password=" + src[1];
        using (WebClient wb = new WebClient()) {
          string response = wb.DownloadString(URL);
          string[] split = response.Split('<');
          response = split[5];
          split = response.Split('>');
          src[2] = split[1];
        }
      }//End Try
      catch { src[2] = "UAC could not be found."; }
    }

    #endregion

    #region InputBoxes
    public TextBox mreturnjson= new TextBox();
    public TextBox msessioncode = new TextBox();
    public TextBox moldpassword = new TextBox();
    public TextBox mnewpassword = new TextBox();
    public TextBox musername = new TextBox();
    public TextBox mpassword = new TextBox();
    public TextBox memailaddress = new TextBox();
    public TextBox mverificationcode = new TextBox();
    public TextBox mrecipientusername = new TextBox();
    public TextBox mnewrole = new TextBox();
    public TextBox maddedcoverage = new TextBox();
    public TextBox mrevokedcoverage = new TextBox();
    public TextBox mincludecoverage = new TextBox();
    public TextBox mtargetusername = new TextBox();
    public TextBox mlimittouser = new TextBox();
    public TextBox mtargets = new TextBox();
    public TextBox mmethod = new TextBox();
    public TextBox mmaxresults = new TextBox();
    public TextBox mtargetassignment = new TextBox();
    public TextBox mfiltertype = new TextBox();
    public TextBox mintersectiontype = new TextBox();
    public TextBox mlatitude = new TextBox();
    public TextBox mlongitude = new TextBox();
    public TextBox mregion = new TextBox();
    public TextBox musegroups = new TextBox();
    public TextBox mgroupbysignal = new TextBox();
    public TextBox musequarantine = new TextBox();
    public TextBox mscnr = new TextBox();
    public TextBox mverificationstatus = new TextBox();
    public TextBox mmaxdistance = new TextBox();
    public TextBox mheading = new TextBox();
    public TextBox mtargetdate = new TextBox();
    public TextBox mtabletype = new TextBox();
    public TextBox mtargetstartdate = new TextBox();
    public TextBox mtargetenddate = new TextBox();
    public TextBox mlivetiminginfo = new TextBox();
    public TextBox mgroupnr = new TextBox();
    public TextBox mincludepredictions = new TextBox();
    public TextBox mincludezeroconfidencepredictions = new TextBox();
    public TextBox mincludetopology = new TextBox();
    public TextBox madjustforlatency = new TextBox();
    public TextBox mhorizon = new TextBox();
    public TextBox mresponseformat = new TextBox();
    public TextBox msourceusername = new TextBox();
    public TextBox mfromtime = new TextBox();
    public TextBox mtotime = new TextBox();
    public TextBox mencodedata = new TextBox();
    public TextBox mgroup = new TextBox();
    public TextBox mlatencycorrection = new TextBox();
    public TextBox mClientAddress = new TextBox();
    public TextBox mUpdates = new TextBox();
    public TextBox mHosts = new TextBox();
    public TextBox mIDs = new TextBox();
    public TextBox mServer = new TextBox();
    public TextBox mKeys = new TextBox();
    public TextBox mConnections = new TextBox();
    public TextBox mReturnJSON = new TextBox();
    public TextBox malerts = new TextBox();
    public TextBox mipAddress = new TextBox();
    public TextBox mRegions = new TextBox();
    public TextBox mPath = new TextBox();
    public TextBox mLiveGroups = new TextBox();
    public TextBox mRegionNames = new TextBox();
    public TextBox mD4File = new TextBox();
    public TextBox mFixedTime = new TextBox();
    public TextBox mActuated = new TextBox();
    public TextBox mFreeRunning = new TextBox();
    public TextBox mApproach = new TextBox();
    public TextBox mVersion = new TextBox();
    public TextBox mRegionID = new TextBox();
    public TextBox mTSPackage = new TextBox();
    public TextBox mCredentials = new TextBox();
    public TextBox mData = new TextBox();
    public TextBox mDate = new TextBox();
    public TextBox mMode = new TextBox();
    public TextBox mHorizons = new TextBox();
    public TextBox mHours = new TextBox();
    public TextBox mSpan = new TextBox();
    public TextBox mTestPassesIfContains = new TextBox();

    #endregion

    #region Labels
    public Label returnjson = new Label();
    public Label sessioncode = new Label();
    public Label oldpassword = new Label();
    public Label newpassword = new Label();
    public Label username = new Label();
    public Label password = new Label();
    public Label emailaddress = new Label();
    public Label verificationcode = new Label();
    public Label recipientusername = new Label();
    public Label newrole = new Label();
    public Label addedcoverage = new Label();
    public Label revokedcoverage = new Label();
    public Label includecoverage = new Label();
    public Label targetusername = new Label();
    public Label limittouser = new Label();
    public Label targets = new Label();
    public Label method = new Label();
    public Label maxresults = new Label();
    public Label targetassignment = new Label();
    public Label filtertype = new Label();
    public Label intersectiontype = new Label();
    public Label latitude = new Label();
    public Label longitude = new Label();
    public Label region = new Label();
    public Label usegroups = new Label();
    public Label groupbysignal = new Label();
    public Label usequarantine = new Label();
    public Label scnr = new Label();
    public Label verificationstatus = new Label();
    public Label maxdistance = new Label();
    public Label heading = new Label();
    public Label targetdate = new Label();
    public Label tabletype = new Label();
    public Label targetstartdate = new Label();
    public Label targetenddate = new Label();
    public Label livetiminginfo = new Label();
    public Label groupnr = new Label();
    public Label includepredictions = new Label();
    public Label includezeroconfidencepredictions = new Label();
    public Label includetopology = new Label();
    public Label adjustforlatency = new Label();
    public Label horizon = new Label();
    public Label responseformat = new Label();
    public Label sourceusername = new Label();
    public Label fromtime = new Label();
    public Label totime = new Label();
    public Label encodedata = new Label();
    public Label group = new Label();
    public Label latencycorrection = new Label();
    public Label ClientAddress = new Label();
    public Label Updates = new Label();
    public Label Hosts = new Label();
    public Label IDs = new Label();
    public Label Server = new Label();
    public Label Keys = new Label();
    public Label Connections = new Label();
    public Label ReturnJSON = new Label();
    public Label alerts = new Label();
    public Label ipAddress = new Label();
    public Label Regions = new Label();
    public Label Path = new Label();
    public Label LiveGroups = new Label();
    public Label RegionNames = new Label();
    public Label D4File = new Label();
    public Label FixedTime = new Label();
    public Label Actuated = new Label();
    public Label FreeRunning = new Label();
    public Label Approach = new Label();
    public Label Version = new Label();
    public Label RegionID = new Label();
    public Label TSPackage = new Label();
    public Label Credentials = new Label();
    public Label Data = new Label();
    public Label Date = new Label();
    public Label Mode = new Label();
    public Label Horizons = new Label();
    public Label Hours = new Label();
    public Label Span = new Label();
    public Label TestPassesIfContains = new Label();

    #endregion

    #region URLS
    public List<string> mreturnjsonURLS = new List<string> {"http://localhost:6247/APhA/Services/CreateUser", "http://localhost:6247/APhA/Services/VerifyEmail", "http://localhost:6247/APhA/Services/ResetPassword", "http://localhost:6247/APhA/Services/VerifyResetPassword", "http://localhost:6247/APhA/Services/Login", "http://localhost:6247/APhA/Services/ChangePassword", "http://localhost:6247/APhA/Services/RenewSession", "http://localhost:6247/APhA/Services/ChangeRole", "http://localhost:6247/APhA/Services/ChangeCoverage", "http://localhost:6247/APhA/Services/GetUsers", "http://localhost:6247/APhA/Services/GetUsersCoverage", "http://localhost:6247/APhA/Services/DeleteAccount", "http://localhost:6711/APhA/Services/ServerMap", "http://localhost:6711/APhA/Services/IntersectionMap", "http://localhost:6441/APhA/Services/SupplierMap", "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology", "http://localhost:6317/APhA/Services/TopologyDate", "http://localhost:6317/APhA/Services/NextIntersection", "http://localhost:5942/APhA/Services/GetRegionSCDBDataRequest", "http://localhost:5942/APhA/Services/GetStatusDBDataRequest", "http://localhost:5942/APhA/Services/GetPredictionsDBDataRequest", "http://localhost:5942/APhA/Services/GetControllerInputDataRequest", "http://localhost:5942/APhA/Services/GetLogicDBDataRequest", "http://localhost:5942/APhA/Services/GetQuarantineDataRequest", "http://localhost:5942/APhA/Services/GetCurrentVersionRequest", "http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest", "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest", "http://localhost:5942/APhA/Services/GetRelevantPhasesDataRequest", "http://localhost:6240/APhA/Services/LatestStatus", "http://localhost:6240/APhA/Services/Predictions", "http://localhost:6240/APhA/Services/LatestTimingPlan", "http://localhost:6240/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/LatestStatus", "http://localhost:6260/APhA/Services/LatestTimingPlan", "http://localhost:6260/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/RecentSwitchEvents", "http://localhost:6416/APhA/Services/LatestStatus", "http://localhost:5831/APhA/Services/Predictions"};
    public List<string> msessioncodeURLS = new List<string> {"http://localhost:6247/APhA/Services/ChangePassword", "http://localhost:6247/APhA/Services/RenewSession", "http://localhost:6247/APhA/Services/ChangeRole", "http://localhost:6247/APhA/Services/ChangeCoverage", "http://localhost:6247/APhA/Services/GetUsers", "http://localhost:6247/APhA/Services/GetUsersCoverage", "http://localhost:6247/APhA/Services/DeleteAccount", "http://localhost:6711/APhA/Services/ServerMap", "http://localhost:6711/APhA/Services/UpdateCoverage", "http://localhost:6711/APhA/Services/CreateHosts", "http://localhost:6711/APhA/Services/UpdateHosts", "http://localhost:6711/APhA/Services/DeleteHosts", "http://localhost:6711/APhA/Services/CreateServerCoverage", "http://localhost:6711/APhA/Services/UpdateServerCoverage", "http://localhost:6711/APhA/Services/DeleteServerCoverage", "http://localhost:6711/APhA/Services/CreateServerConnections", "http://localhost:6711/APhA/Services/UpdateServerConnections", "http://localhost:6711/APhA/Services/DeleteServerConnections", "http://localhost:6711/APhA/Services/GetIntersectionMap", "http://localhost:6711/APhA/Services/IntersectionMap", "http://localhost:6441/APhA/Services/SupplierMap", "http://localhost:5601/APhA/Services/GetAlerts", "http://localhost:5601/APhA/Services/GetUnsentAlerts", "http://localhost:5601/APhA/Services/UpdateSent", "http://localhost:5602/APhA/Services/RelayAlerts", "http://localhost:5602/APhA/Services/GetAlerts", "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology", "http://localhost:6317/APhA/Services/TopologyDate", "http://localhost:6317/APhA/Services/NextIntersection", "http://localhost:6317/APhA/Services/IntersectionStatus", "http://localhost:6317/APhA/Services/IntersectionTopology", "http://localhost:6317/APhA/Services/CreateIntersections", "http://localhost:6317/APhA/Services/UpdateIntersections", "http://localhost:6317/APhA/Services/DeleteIntersections", "http://localhost:6317/APhA/Services/CreateRegions", "http://localhost:6317/APhA/Services/UpdateRegions", "http://localhost:6317/APhA/Services/DeleteRegions", "http://localhost:6317/APhA/Services/UpdateIntersectionTopology", "http://localhost:6317/APhA/Services/DeleteIntersectionTopology", "http://localhost:6317/APhA/Services/ReadIntersections", "http://localhost:6317/APhA/Services/PostTopologyJSON", "http://localhost:6317/APhA/Services/PostD4", "http://localhost:6317/APhA/Services/UpdateIntersectionType", "http://localhost:6250/APhA/Services/TopologyCorrection", "http://localhost:6250/APhA/Services/CreateProtPermQuarantine", "http://localhost:6250/APhA/Services/ReadProtPermQuarantine", "http://localhost:6250/APhA/Services/UpdateProtPermQuarantine", "http://localhost:6250/APhA/Services/DeleteProtPermQuarantine", "http://localhost:6250/APhA/Services/CreateProtPermOverride", "http://localhost:6250/APhA/Services/ReadProtPermOverride", "http://localhost:6250/APhA/Services/UpdateProtPermOverride", "http://localhost:6250/APhA/Services/DeleteProtPermOverride", "http://localhost:5942/APhA/Services/GetRegionSCDBDataRequest", "http://localhost:5942/APhA/Services/GetStatusDBDataRequest", "http://localhost:5942/APhA/Services/GetPredictionsDBDataRequest", "http://localhost:5942/APhA/Services/GetControllerInputDataRequest", "http://localhost:5942/APhA/Services/GetLogicDBDataRequest", "http://localhost:5942/APhA/Services/GetQuarantineDataRequest", "http://localhost:5942/APhA/Services/GetCurrentVersionRequest", "http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest", "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest", "http://localhost:5942/APhA/Services/GetRelevantPhasesDataRequest", "http://localhost:6240/APhA/Services/FixedTimeStatusImporter", "http://localhost:6240/APhA/Services/FixedTimePlanImporter", "http://localhost:6240/APhA/Services/LatestStatus", "http://localhost:6240/APhA/Services/Predictions", "http://localhost:6240/APhA/Services/LatestTimingPlan", "http://localhost:6240/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/StatusImporter", "http://localhost:6260/APhA/Services/LatestTimingPlan", "http://localhost:6260/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/TimingPlanImporter", "http://localhost:6260/APhA/Services/LatestStatus", "http://localhost:6260/APhA/Services/RecentSwitchEvents", "http://localhost:6260/APhA/Services/StatusHistory", "http://localhost:6416/APhA/Services/GevasStatusImporter", "http://localhost:6416/APhA/Services/LatestStatus", "http://localhost:5831/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/LatencyCorrection", "http://localhost:5831/APhA/Services/ControllerStatus", "http://localhost:5831/APhA/Services/UpdateIntersectionType", "http://localhost:5831/APhA/Services/SubmitPredictions", "http://localhost:6777/APhA/Services/ReadConfidence" };
    public List<string> moldpasswordURLS = new List<string> { "http://localhost:6247/APhA/Services/ChangePassword" };
    public List<string> mnewpasswordURLS = new List<string> { "http://localhost:6247/APhA/Services/ChangePassword" };
    public List<string> musernameURLS = new List<string> { "http://localhost:6247/APhA/Services/CreateUser", "http://localhost:6247/APhA/Services/ResetPassword", "http://localhost:6247/APhA/Services/Login", "http://localhost:6250/APhA/Services/TopologyCorrection", "http://localhost:6260/APhA/Services/TimingPlanImporter" };
    public List<string> mpasswordURLS = new List<string> { "http://localhost:6247/APhA/Services/CreateUser", "http://localhost:6247/APhA/Services/Login", "http://localhost:6247/APhA/Services/DeleteAccount", "http://localhost:6260/APhA/Services/TimingPlanImporter" };
    public List<string> memailaddressURLS = new List<string> { "http://localhost:6247/APhA/Services/CreateUser" };
    public List<string> mverificationcodeURLS = new List<string> { "http://localhost:6247/APhA/Services/VerifyEmail", "http://localhost:6247/APhA/Services/VerifyResetPassword" };
    public List<string> mrecipientusernameURLS = new List<string> { "http://localhost:6247/APhA/Services/ChangeRole", "http://localhost:6247/APhA/Services/ChangeCoverage" };
    public List<string> mnewroleURLS = new List<string> { "http://localhost:6247/APhA/Services/ChangeRole" };
    public List<string> maddedcoverageURLS = new List<string> { "http://localhost:6247/APhA/Services/ChangeCoverage" };
    public List<string> mrevokedcoverageURLS = new List<string> { "http://localhost:6247/APhA/Services/ChangeCoverage" };
    public List<string> mincludecoverageURLS = new List<string> { "http://localhost:6247/APhA/Services/GetUsers" };
    public List<string> mtargetusernameURLS = new List<string> { "http://localhost:6247/APhA/Services/GetUsersCoverage" };
    public List<string> mlimittouserURLS = new List<string> { "http://localhost:6711/APhA/Services/ServerMap", "http://localhost:6711/APhA/Services/Coverage" };
    public List<string> mtargetsURLS = new List<string> { "http://localhost:6711/APhA/Services/IntersectionMap", "http://localhost:6441/APhA/Services/SupplierMap", "http://localhost:6250/APhA/Services/ReadProtPermQuarantine", "http://localhost:6250/APhA/Services/ReadProtPermOverride", "http://localhost:6240/APhA/Services/LatestStatus", "http://localhost:6240/APhA/Services/Predictions", "http://localhost:6240/APhA/Services/LatestTimingPlan", "http://localhost:6240/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/LatestStatus", "http://localhost:6260/APhA/Services/LatestTimingPlan", "http://localhost:6260/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/RecentSwitchEvents", "http://localhost:6260/APhA/Services/StatusHistory", "http://localhost:6416/APhA/Services/LatestStatus", "http://localhost:5831/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/ControllerStatus", "http://localhost:6711/APhA/Services/GetIntersectionMap", "http://localhost:6317/APhA/Services/IntersectionTopology", "http://localhost:6250/APhA/Services/UpdateProtPermQuarantine" };
    public List<string> mmethodURLS = new List<string> { "http://localhost:6317/APhA/Services/Coverage" };
    public List<string> mmaxresultsURLS = new List<string> { "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology", "http://localhost:6317/APhA/Services/NextIntersection" };
    public List<string> mtargetassignmentURLS = new List<string> { "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology" };
    public List<string> mfiltertypeURLS = new List<string> { "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology" };
    public List<string> mintersectiontypeURLS = new List<string> { "http://localhost:6317/APhA/Services/Coverage" };
    public List<string> mlatitudeURLS = new List<string> { "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology", "http://localhost:6317/APhA/Services/NextIntersection" };
    public List<string> mlongitudeURLS = new List<string> { "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology", "http://localhost:6317/APhA/Services/NextIntersection" };
    public List<string> mregionURLS = new List<string> { "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology", "http://localhost:6317/APhA/Services/IntersectionStatus", "http://localhost:5942/APhA/Services/GetRegionSCDBDataRequest", "http://localhost:5942/APhA/Services/GetStatusDBDataRequest", "http://localhost:5942/APhA/Services/GetPredictionsDBDataRequest", "http://localhost:5942/APhA/Services/GetControllerInputDataRequest", "http://localhost:5942/APhA/Services/GetLogicDBDataRequest", "http://localhost:5942/APhA/Services/GetQuarantineDataRequest", "http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest", "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest", "http://localhost:5942/APhA/Services/GetRelevantPhasesDataRequest", "http://localhost:5831/APhA/Services/LatencyCorrection", "http://localhost:6317/APhA/Services/PostTopologyJSON", "http://localhost:6317/APhA/Services/PostD4", "http://localhost:6250/APhA/Services/TopologyCorrection", "http://localhost:6777/APhA/Services/ReadConfidence" };
    public List<string> musegroupsURLS = new List<string> { "http://localhost:6317/APhA/Services/Coverage" };
    public List<string> mgroupbysignalURLS = new List<string> { "http://localhost:6317/APhA/Services/Topology" };
    public List<string> musequarantineURLS = new List<string> { "http://localhost:6317/APhA/Services/Topology", "http://localhost:6240/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/Predictions" };
    public List<string> mscnrURLS = new List<string> { "http://localhost:6317/APhA/Services/IntersectionStatus", "http://localhost:5942/APhA/Services/GetStatusDBDataRequest", "http://localhost:5942/APhA/Services/GetPredictionsDBDataRequest", "http://localhost:5942/APhA/Services/GetControllerInputDataRequest", "http://localhost:5942/APhA/Services/GetLogicDBDataRequest", "http://localhost:5942/APhA/Services/GetQuarantineDataRequest", "http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest", "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest", "http://localhost:5942/APhA/Services/GetRelevantPhasesDataRequest", "http://localhost:5831/APhA/Services/LatencyCorrection", "http://localhost:6317/APhA/Services/PostD4", "http://localhost:6250/APhA/Services/TopologyCorrection" };
    public List<string> mverificationstatusURLS = new List<string> { "http://localhost:6317/APhA/Services/IntersectionStatus" };
    public List<string> mmaxdistanceURLS = new List<string> { "http://localhost:6317/APhA/Services/NextIntersection" };
    public List<string> mheadingURLS = new List<string> { "http://localhost:6317/APhA/Services/NextIntersection" };
    public List<string> mtargetdateURLS = new List<string> { "http://localhost:5942/APhA/Services/GetStatusDBDataRequest", "http://localhost:5942/APhA/Services/GetPredictionsDBDataRequest", "http://localhost:5942/APhA/Services/GetLogicDBDataRequest", "http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest" };
    public List<string> mtabletypeURLS = new List<string> { "http://localhost:5942/APhA/Services/GetLogicDBDataRequest", "http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest" };
    public List<string> mtargetstartdateURLS = new List<string> { "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest" };
    public List<string> mtargetenddateURLS = new List<string> { "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest" };
    public List<string> mlivetiminginfoURLS = new List<string> { "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest" };
    public List<string> mgroupnrURLS = new List<string> { "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest" };
    public List<string> mincludepredictionsURLS = new List<string> { "http://localhost:6240/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/Predictions" };
    public List<string> mincludezeroconfidencepredictionsURLS = new List<string> { "http://localhost:6240/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/Predictions" };
    public List<string> mincludetopologyURLS = new List<string> { "http://localhost:6240/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/Predictions" };
    public List<string> madjustforlatencyURLS = new List<string> { "http://localhost:6240/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/Predictions" };
    public List<string> mhorizonURLS = new List<string> { "http://localhost:6240/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/Predictions" };
    public List<string> mresponseformatURLS = new List<string> { "http://localhost:6240/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/Predictions" };
    public List<string> msourceusernameURLS = new List<string> { "http://localhost:6240/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/Predictions" };
    public List<string> mfromtimeURLS = new List<string> { "http://localhost:6260/APhA/Services/RecentSwitchEvents" };
    public List<string> mtotimeURLS = new List<string> { "http://localhost:6260/APhA/Services/RecentSwitchEvents" };
    public List<string> mencodedataURLS = new List<string> { "http://localhost:6260/APhA/Services/RecentSwitchEvents" };
    public List<string> mgroupURLS = new List<string> { "http://localhost:5831/APhA/Services/LatencyCorrection" };
    public List<string> mlatencycorrectionURLS = new List<string> { "http://localhost:5831/APhA/Services/LatencyCorrection" };
    public List<string> mClientAddressURLS = new List<string> { "http://localhost:6711/APhA/Services/UpdateCoverage", "http://localhost:6711/APhA/Services/CreateHosts", "http://localhost:6711/APhA/Services/UpdateHosts", "http://localhost:6711/APhA/Services/DeleteHosts", "http://localhost:6711/APhA/Services/CreateServerCoverage", "http://localhost:6711/APhA/Services/UpdateServerCoverage", "http://localhost:6711/APhA/Services/DeleteServerCoverage", "http://localhost:6711/APhA/Services/CreateServerConnections", "http://localhost:6711/APhA/Services/UpdateServerConnections", "http://localhost:6711/APhA/Services/DeleteServerConnections", "http://localhost:6711/APhA/Services/GetIntersectionMap", "http://localhost:6317/APhA/Services/IntersectionTopology", "http://localhost:6317/APhA/Services/CreateIntersections", "http://localhost:6317/APhA/Services/UpdateIntersections", "http://localhost:6317/APhA/Services/DeleteIntersections", "http://localhost:6317/APhA/Services/CreateRegions", "http://localhost:6317/APhA/Services/UpdateRegions", "http://localhost:6317/APhA/Services/DeleteRegions", "http://localhost:6317/APhA/Services/UpdateIntersectionTopology", "http://localhost:6317/APhA/Services/DeleteIntersectionTopology", "http://localhost:6317/APhA/Services/ReadIntersections", "http://localhost:6317/APhA/Services/PostTopologyJSON", "http://localhost:6317/APhA/Services/PostD4", "http://localhost:6317/APhA/Services/UpdateIntersectionType", "http://localhost:6250/APhA/Services/CreateProtPermQuarantine", "http://localhost:6250/APhA/Services/UpdateProtPermQuarantine", "http://localhost:6250/APhA/Services/DeleteProtPermQuarantine", "http://localhost:6250/APhA/Services/CreateProtPermOverride", "http://localhost:6250/APhA/Services/UpdateProtPermOverride", "http://localhost:6250/APhA/Services/DeleteProtPermOverride", "http://localhost:5831/APhA/Services/UpdateIntersectionType" };
    public List<string> mUpdatesURLS = new List<string> { "http://localhost:6711/APhA/Services/UpdateCoverage" };
    public List<string> mHostsURLS = new List<string> { "http://localhost:6711/APhA/Services/CreateHosts", "http://localhost:6711/APhA/Services/UpdateHosts" };
    public List<string> mIDsURLS = new List<string> { "http://localhost:6711/APhA/Services/DeleteHosts", "http://localhost:6711/APhA/Services/DeleteServerConnections" };
    public List<string> mServerURLS = new List<string> { "http://localhost:6711/APhA/Services/CreateServerCoverage", "http://localhost:6711/APhA/Services/UpdateServerCoverage" };
    public List<string> mKeysURLS = new List<string> { "http://localhost:6711/APhA/Services/DeleteServerCoverage" };
    public List<string> mConnectionsURLS = new List<string> { "http://localhost:6711/APhA/Services/CreateServerConnections", "http://localhost:6711/APhA/Services/UpdateServerConnections" };
    public List<string> mReturnJSONURLS = new List<string> { "http://localhost:6711/APhA/Services/GetIntersectionMap" };
    public List<string> malertsURLS = new List<string> { "http://localhost:5601/APhA/Services/RaiseAlerts" };
    public List<string> mipAddressURLS = new List<string> { "http://localhost:5602/APhA/Services/RelayAlerts" };
    public List<string> mRegionsURLS = new List<string> { "http://localhost:6317/APhA/Services/CreateIntersections", "http://localhost:6317/APhA/Services/UpdateIntersections", "http://localhost:6317/APhA/Services/DeleteIntersections", "http://localhost:6317/APhA/Services/CreateRegions", "http://localhost:6317/APhA/Services/UpdateRegions", "http://localhost:6317/APhA/Services/DeleteIntersectionTopology", "http://localhost:6317/APhA/Services/ReadIntersections", "http://localhost:6250/APhA/Services/CreateProtPermQuarantine", "http://localhost:6250/APhA/Services/UpdateProtPermQuarantine", "http://localhost:6250/APhA/Services/DeleteProtPermQuarantine", "http://localhost:6250/APhA/Services/CreateProtPermOverride", "http://localhost:6250/APhA/Services/UpdateProtPermOverride", "http://localhost:6250/APhA/Services/DeleteProtPermOverride" };
    public List<string> mPathURLS = new List<string> { "http://localhost:6317/APhA/Services/CreateRegions" };
    public List<string> mLiveGroupsURLS = new List<string> { "http://localhost:6317/APhA/Services/CreateRegions", "http://localhost:6317/APhA/Services/UpdateRegions" };
    public List<string> mRegionNamesURLS = new List<string> { "http://localhost:6317/APhA/Services/DeleteRegions", "http://localhost:6317/APhA/Services/UpdateIntersectionTopology" };
    public List<string> mD4FileURLS = new List<string> { "http://localhost:6317/APhA/Services/PostD4" };
    public List<string> mFixedTimeURLS = new List<string> { "http://localhost:6317/APhA/Services/UpdateIntersectionType", "http://localhost:5831/APhA/Services/UpdateIntersectionType" };
    public List<string> mActuatedURLS = new List<string> { "http://localhost:6317/APhA/Services/UpdateIntersectionType", "http://localhost:5831/APhA/Services/UpdateIntersectionType" };
    public List<string> mFreeRunningURLS = new List<string> { "http://localhost:6317/APhA/Services/UpdateIntersectionType", "http://localhost:5831/APhA/Services/UpdateIntersectionType" };
    public List<string> mApproachURLS = new List<string> { "http://localhost:6250/APhA/Services/TopologyCorrection" };
    public List<string> mVersionURLS = new List<string> { "http://localhost:6240/APhA/Services/FixedTimeStatusImporter", "http://localhost:6240/APhA/Services/FixedTimePlanImporter", "http://localhost:6260/APhA/Services/StatusImporter", "http://localhost:6260/APhA/Services/TimingPlanImporter", "http://localhost:6416/APhA/Services/GevasStatusImporter", "http://localhost:5831/APhA/Services/SubmitPredictions" };
    public List<string> mRegionIDURLS = new List<string> { "http://localhost:6240/APhA/Services/FixedTimeStatusImporter", "http://localhost:6240/APhA/Services/FixedTimePlanImporter", "http://localhost:6260/APhA/Services/StatusImporter", "http://localhost:6260/APhA/Services/TimingPlanImporter" };
    public List<string> mTSPackageURLS = new List<string> { "http://localhost:6240/APhA/Services/FixedTimeStatusImporter", "http://localhost:6240/APhA/Services/FixedTimePlanImporter", "http://localhost:6260/APhA/Services/TimingPlanImporter", "http://localhost:6416/APhA/Services/GevasStatusImporter" };
    public List<string> mCredentialsURLS = new List<string> { "http://localhost:6260/APhA/Services/TimingPlanImporter" };
    public List<string> mDataURLS = new List<string> { "http://localhost:6260/APhA/Services/TimingPlanImporter", "http://localhost:5831/APhA/Services/SubmitPredictions" };
    public List<string> mDateURLS = new List<string> { "http://localhost:6777/APhA/Services/ReadConfidence" };
    public List<string> mModeURLS = new List<string> { "http://localhost:6777/APhA/Services/ReadConfidence" };
    public List<string> mHorizonsURLS = new List<string> { "http://localhost:6777/APhA/Services/ReadConfidence" };
    public List<string> mHoursURLS = new List<string> { "http://localhost:6777/APhA/Services/ReadConfidence" };
    public List<string> mSpanURLS = new List<string> { "http://localhost:6260/APhA/Services/StatusHistory" };
    public List<string> mTestPassesIfContainsURLS = new List<string> { "http://localhost:6247/APhA/Services/CreateUser", "http://localhost:6247/APhA/Services/VerifyEmail", "http://localhost:6247/APhA/Services/ResetPassword", "http://localhost:6247/APhA/Services/VerifyResetPassword", "http://localhost:6247/APhA/Services/Login", "http://localhost:6247/APhA/Services/ChangePassword", "http://localhost:6247/APhA/Services/RenewSession", "http://localhost:6247/APhA/Services/ChangeRole", "http://localhost:6247/APhA/Services/ChangeCoverage", "http://localhost:6247/APhA/Services/GetUsers", "http://localhost:6247/APhA/Services/GetUsersCoverage", "http://localhost:6247/APhA/Services/DeleteAccount", "http://localhost:6711/APhA/Services/ServerMap", "http://localhost:6711/APhA/Services/IntersectionMap", "http://localhost:6441/APhA/Services/SupplierMap", "http://localhost:6317/APhA/Services/Coverage", "http://localhost:6317/APhA/Services/Topology", "http://localhost:6317/APhA/Services/TopologyDate", "http://localhost:6317/APhA/Services/NextIntersection", "http://localhost:6317/APhA/Services/IntersectionStatus", "http://localhost:6250/APhA/Services/ReadProtPermQuarantine", "http://localhost:6250/APhA/Services/ReadProtPermOverride", "http://localhost:5942/APhA/Services/GetRegionSCDBDataRequest", "http://localhost:5942/APhA/Services/GetStatusDBDataRequest", "http://localhost:5942/APhA/Services/GetPredictionsDBDataRequest", "http://localhost:5942/APhA/Services/GetControllerInputDataRequest", "http://localhost:5942/APhA/Services/GetLogicDBDataRequest", "http://localhost:5942/APhA/Services/GetQuarantineDataRequest", "http://localhost:5942/APhA/Services/GetCurrentVersionRequest", "http://localhost:5942/APhA/Services/GetConfidenceDBDataRequest", "http://localhost:5942/APhA/Services/GetTimingPlanDBDataRequest", "http://localhost:5942/APhA/Services/GetRelevantPhasesDataRequest", "http://localhost:6240/APhA/Services/LatestStatus", "http://localhost:6240/APhA/Services/Predictions", "http://localhost:6240/APhA/Services/LatestTimingPlan", "http://localhost:6240/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/LatestStatus", "http://localhost:6260/APhA/Services/LatestTimingPlan", "http://localhost:6260/APhA/Services/LatestTimingPlanInfo", "http://localhost:6260/APhA/Services/RecentSwitchEvents", "http://localhost:6260/APhA/Services/StatusHistory", "http://localhost:6416/APhA/Services/LatestStatus", "http://localhost:5831/APhA/Services/Predictions", "http://localhost:5831/APhA/Services/LatencyCorrection", "http://localhost:5831/APhA/Services/ControllerStatus", "http://localhost:5601/APhA/Services/GetAlerts", "http://localhost:5601/APhA/Services/GetUnsentAlerts", "http://localhost:5602/APhA/Services/GetAlerts", "http://localhost:6711/APhA/Services/UpdateCoverage", "http://localhost:6711/APhA/Services/CreateHosts", "http://localhost:6711/APhA/Services/UpdateHosts", "http://localhost:6711/APhA/Services/DeleteHosts", "http://localhost:6711/APhA/Services/CreateServerCoverage", "http://localhost:6711/APhA/Services/CreateServerConnections", "http://localhost:6711/APhA/Services/UpdateServerConnections", "http://localhost:6711/APhA/Services/DeleteServerConnections", "http://localhost:6711/APhA/Services/GetIntersectionMap", "http://localhost:5601/APhA/Services/RaiseAlerts", "http://localhost:5601/APhA/Services/UpdateSent", "http://localhost:5602/APhA/Services/RelayAlerts", "http://localhost:6317/APhA/Services/IntersectionTopology", "http://localhost:6317/APhA/Services/CreateIntersections", "http://localhost:6317/APhA/Services/UpdateIntersections", "http://localhost:6317/APhA/Services/DeleteIntersections", "http://localhost:6317/APhA/Services/CreateRegions", "http://localhost:6317/APhA/Services/UpdateRegions", "http://localhost:6317/APhA/Services/DeleteRegions", "http://localhost:6317/APhA/Services/UpdateIntersectionTopology", "http://localhost:6317/APhA/Services/DeleteIntersectionTopology", "http://localhost:6317/APhA/Services/ReadIntersections", "http://localhost:6317/APhA/Services/PostTopologyJSON", "http://localhost:6317/APhA/Services/PostD4", "http://localhost:6317/APhA/Services/UpdateIntersectionType", "http://localhost:6250/APhA/Services/TopologyCorrection", "http://localhost:6250/APhA/Services/CreateProtPermQuarantine", "http://localhost:6250/APhA/Services/UpdateProtPermQuarantine", "http://localhost:6250/APhA/Services/DeleteProtPermQuarantine", "http://localhost:6250/APhA/Services/CreateProtPermOverride", "http://localhost:6250/APhA/Services/UpdateProtPermOverride", "http://localhost:6250/APhA/Services/DeleteProtPermOverride", "http://localhost:6240/APhA/Services/FixedTimeStatusImporter", "http://localhost:6240/APhA/Services/FixedTimePlanImporter", "http://localhost:6260/APhA/Services/StatusImporter", "http://localhost:6260/APhA/Services/TimingPlanImporter", "http://localhost:6416/APhA/Services/GevasStatusImporter", "http://localhost:5831/APhA/Services/UpdateIntersectionType", "http://localhost:5831/APhA/Services/SubmitPredictions", "http://localhost:6777/APhA/Services/ReadConfidence"};

    #endregion

    #region InputBox&LabelFormatterFunctions
    public TextBox TTSFormattedTextBox(TextBox src)
    {
      src.AutoSize = true;
      src.MaxLength = 860;
      src.Size = new Size(521, 20);
      src.MinimumSize = new Size(521, 20);
      src.MaximumSize = new Size(860, 20);

      return src;
    }

    public Label TTSFormattedLabel(Label src)
    {
      src.Font = new Font("Verdana", 10);
      src.AutoSize = true;
      src.Text = src.Name.ToString() + ":";
      src.Refresh();
      return src;
    }
    #endregion

    #region Frame
    public TTSRestClientFrame()
    {
      InitializeComponent();
      //check if the ConfiguredRuns directory exists. If it doesn't. Create it.
      if (!Directory.Exists(@"C:\PScripts\ConfiguredRuns")) {
        System.IO.Directory.CreateDirectory(@"C:\PScripts\ConfiguredRuns");
      }

      //grabs the login info file
      #region LoginInfoFile
      if (!File.Exists(@"C:\PScripts\LoginInfo.txt")) {
        File.WriteAllLines(@"C:\PScripts\LoginInfo.txt", new string[] { "UserName", "Password", "SessionCode" }, Encoding.UTF8);
      }
      else {
        try {
          lines = System.IO.File.ReadAllLines(@"C:\PScripts\LoginInfo.txt");
          if (lines.Count() == 0) {
            lines = new string[] { "UserName", "Password", "SessionCode" };
            File.WriteAllLines(@"C:\PScripts\LoginInfo.txt", lines, Encoding.UTF8);
          }
          if (lines.Count() == 1) {
            lines = new string[] { lines[0], "Password", "SessionCode" };
            File.WriteAllLines(@"C:\PScripts\LoginInfo.txt", lines, Encoding.UTF8);
          }
          if (lines.Count() == 2) {
            lines = new string[] { lines[0], lines[1], "SessionCode" };
            File.WriteAllLines(@"C:\PScripts\LoginInfo.txt", lines, Encoding.UTF8);
          }
        }
        catch {
          lines = new string[] { "CatchUserName", "CatchPassword", "CatchSessionCode" };
        }
      }
      #endregion

      SessionCode(lines);
      myInputUser.Text = lines[0];
      musername.Text = lines[0];
      mpassword.Text = lines[1];
      msessioncode.Text = lines[2];
    }
    #endregion

    #region ButtonFunctions
    private void GetInputsButton_Click(object sender, EventArgs e)
    { 
      if (!string.IsNullOrEmpty(ServiceDropDown.Text)) { //Only perform actions if the service drop down is not blank.
        
        //If GetInputs button visible turn it off.
        if (GetInputsButton.Visible == true){
          GetInputsButton.Visible = false;
        }

        //Build the lists you need to build layout
        List<TextBox> myBoxVariables = new List<TextBox> { mreturnjson, msessioncode, moldpassword, mnewpassword, musername, mpassword, memailaddress, mverificationcode, mrecipientusername, mnewrole, maddedcoverage, mrevokedcoverage, mincludecoverage, mtargetusername, mlimittouser, mtargets, mmethod, mmaxresults, mtargetassignment, mfiltertype, mintersectiontype, mlatitude, mlongitude, mregion, musegroups, mgroupbysignal, musequarantine, mscnr, mverificationstatus, mmaxdistance, mheading, mtargetdate, mtabletype, mtargetstartdate, mtargetenddate, mlivetiminginfo, mgroupnr, mincludepredictions, mincludezeroconfidencepredictions, mincludetopology, madjustforlatency, mhorizon, mresponseformat, msourceusername, mfromtime, mtotime, mencodedata, mgroup, mlatencycorrection, mClientAddress, mUpdates, mHosts, mIDs, mServer, mKeys, mConnections, mReturnJSON, malerts, mipAddress, mRegions, mPath, mLiveGroups, mRegionNames, mD4File, mFixedTime, mActuated, mFreeRunning, mApproach, mVersion, mRegionID, mTSPackage, mCredentials, mData, mDate, mMode, mHorizons, mHours, mSpan, mTestPassesIfContains };
        List<Label> myLabelVariables = new List<Label> { returnjson, sessioncode, oldpassword, newpassword, username, password, emailaddress, verificationcode, recipientusername, newrole, addedcoverage, revokedcoverage, includecoverage, targetusername, limittouser, targets, method, maxresults, targetassignment, filtertype, intersectiontype, latitude, longitude, region, usegroups, groupbysignal, usequarantine, scnr, verificationstatus, maxdistance, heading, targetdate, tabletype, targetstartdate, targetenddate, livetiminginfo, groupnr, includepredictions, includezeroconfidencepredictions, includetopology, adjustforlatency, horizon, responseformat, sourceusername, fromtime, totime, encodedata, group, latencycorrection, ClientAddress, Updates, Hosts, IDs, Server, Keys, Connections, ReturnJSON, alerts, ipAddress, Regions, Path, LiveGroups, RegionNames, RegionNames, D4File, FixedTime, Actuated, FreeRunning, Approach, Version, RegionID, TSPackage, Credentials, Data, Date, Mode, Horizons, Hours, TestPassesIfContains };
        List<List<string>> myURLS = new List<List<string>> { mreturnjsonURLS, msessioncodeURLS, moldpasswordURLS, mnewpasswordURLS, musernameURLS, mpasswordURLS, memailaddressURLS, mverificationcodeURLS, mrecipientusernameURLS, mnewroleURLS, maddedcoverageURLS, mrevokedcoverageURLS, mincludecoverageURLS, mtargetusernameURLS, mlimittouserURLS, mtargetsURLS, mmethodURLS, mmaxresultsURLS, mtargetassignmentURLS, mfiltertypeURLS, mintersectiontypeURLS, mlatitudeURLS, mlongitudeURLS, mregionURLS, musegroupsURLS, mgroupbysignalURLS, musequarantineURLS, mscnrURLS, mverificationstatusURLS, mmaxdistanceURLS, mheadingURLS, mtargetdateURLS, mtabletypeURLS, mtargetstartdateURLS, mtargetenddateURLS, mlivetiminginfoURLS, mgroupnrURLS, mincludepredictionsURLS, mincludezeroconfidencepredictionsURLS, mincludetopologyURLS, madjustforlatencyURLS, mhorizonURLS, mresponseformatURLS, msourceusernameURLS, mfromtimeURLS, mtotimeURLS, mencodedataURLS, mgroupURLS, mlatencycorrectionURLS, mClientAddressURLS, mUpdatesURLS, mHostsURLS, mIDsURLS, mServerURLS, mKeysURLS, mConnectionsURLS, mReturnJSONURLS, malertsURLS, mipAddressURLS, mRegionsURLS, mPathURLS, mLiveGroupsURLS, mRegionNamesURLS, mD4FileURLS, mFixedTimeURLS, mActuatedURLS, mFreeRunningURLS, mApproachURLS, mVersionURLS, mRegionIDURLS, mTSPackageURLS, mCredentialsURLS, mDataURLS, mDateURLS, mModeURLS, mHorizonsURLS, mHoursURLS, mSpanURLS, mTestPassesIfContainsURLS };
        List<string> URLHeaders = new List<string> { "returnjson", "sessioncode", "oldpassword", "newpassword", "username", "password", "emailaddress", "verificationcode", "recipientusername", "newrole", "addedcoverage", "revokedcoverage", "includecoverage", "targetusername", "limittouser", "targets", "method", "maxresults", "targetassignment", "filtertype", "intersectiontype", "latitude", "longitude", "region", "usegroups", "groupbysignal", "usequarantine", "scnr", "verificationstatus", "maxdistance", "heading", "targetdate", "tabletype", "targetstartdate", "targetenddate", "livetiminginfo", "groupnr", "includepredictions", "includezeroconfidencepredictions", "includetopology", "adjustforlatency", "horizon", "responseformat", "sourceusername", "fromtime", "totime", "encodedata", "group", "latencycorrection", "ClientAddress", "Updates", "Hosts", "IDs", "Server", "Keys", "Connections", "ReturnJSON", "alerts", "ipAddress", "Regions", "Path", "LiveGroups", "RegionNames", "RegionNames", "D4File", "FixedTime", "Actuated", "FreeRunning", "Approach", "Version", "RegionID", "TSPackage", "Credentials", "Data", "Date", "Mode", "Horizons", "Hours", "TestPassesIfContains" };

        //Formate all textboxes from your lists
        foreach (TextBox myTextBox in myBoxVariables) {
          TTSFormattedTextBox(myTextBox);
        }

        //Set the Name Property of all Labels from your lists
        for (int i = 0; i < myLabelVariables.Count; i++ ) {
          myLabelVariables[i].Name = myLabels[i];
          myBoxVariables[i].Name = myLabels[i];
        }

        //Formate all Labels from your lists
        foreach (Label myLabel in myLabelVariables) {
          TTSFormattedLabel(myLabel);
        }

        //Dynamically build the form with inputs.
        for (int i = 0; i < myURLS.Count; i++) {//For loop 1

          if (myURLS[i].Contains(ServiceDropDown.Text)) {//If1
          
            myUsedControlBoxes.Add(myBoxVariables[i]);
            myUsedControlLabels.Add(myLabelVariables[i]);
            myUsedURLHeaders.Add(URLHeaders[i]);
            

            myLabelVariables[i].Location = new Point(Servicelabel.Location.X, (CloseButton.Location.Y + (myUsedControlBoxes.Count * 30) + 30));
            this.Controls.Add(myLabelVariables[i]);

            myBoxVariables[i].Location = new Point((myLabelVariables[i].Location.X + myLabelVariables[i].Size.Width + 3), myLabelVariables[i].Location.Y);
            this.Controls.Add(myBoxVariables[i]);
            this.Refresh();
          }//End If1
        }//End For loop
        
        //Read in ConfiguredRuns Files
        if (!File.Exists(myFilePath + myFileDictionary[ServiceDropDown.Text] + ".txt")) {
          File.WriteAllLines(myFilePath + myFileDictionary[ServiceDropDown.Text] + ".txt", new string[myUsedControlBoxes.Count], Encoding.UTF8);
        }

        else {
          ConfiguredRunsLines = System.IO.File.ReadAllLines(myFilePath + myFileDictionary[ServiceDropDown.Text] + ".txt");
          for (int i = 0; i < myUsedControlBoxes.Count; i++) {
            try {
              if (myUsedControlBoxes[i].Text == string.Empty && ConfiguredRunsLines[i] != string.Empty) {
                myUsedControlBoxes[i].Text = ConfiguredRunsLines[i];
              }
            }
            catch {
              myUsedControlBoxes[i].Text = "";
            }
          }

        }

        //Turn on CustomURL label, button and CopyService Button
        CustomURLLabel.Visible = true; 
        CustomURLBox.Visible = true; 
        copyServiceButton.Visible = true;

        //Place and turn on the Clear Button
        ClearButton.Location = new Point(CloseButton.Location.X, (CloseButton.Location.Y + ((myUsedControlBoxes.Count + 2) * 30)));
        ClearButton.Visible = true;

        //Place and turn on the Run Request Button
        RunRequest.Visible = true; //Have to turn on the button before you can use it's size attributes.
        RunRequest.Location = new Point(((this.Size.Width - RunRequest.Size.Width - ((RunRequest.Size.Width - CloseButton.Size.Width)/2))/2), (ClearButton.Location.Y + 30) );
        
        //Place and turn on the Save Runs Button
        SaveRun.Visible = true;
        SaveRun.Location = new Point(RunRequest.Location.X + RunRequest.Size.Width + 3, (RunRequest.Location.Y));

        //Place and turn on Load Button
        ChooseFileButton.Visible = true;
        ChooseFileButton.Location = new Point(RunRequest.Location.X - ChooseFileButton.Size.Width - 3, RunRequest.Location.Y);

      }//End check if Service DropDown is blank or empty.
    }//End GetInputsButton_Click()

    private void CloseButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
      //Remove all used ComboBoxes
      foreach (TextBox Box in myUsedControlBoxes) {
        Box.Clear();
        this.Controls.Remove(Box);
      }
      
      //Remove all used labels
      foreach (Label label in myUsedControlLabels) {
        this.Controls.Remove(label);
      }

      #region Empty/ReAssign
      myUsedControlBoxes.Clear(); //Empty the ComboBoxes
      musername.Text = lines[0]; //Reassign default from input config file
      mpassword.Text = lines[1]; //Reassign default from input config file
      msessioncode.Text = lines[2]; //Reassign default from input config file
      myUsedURLHeaders.Clear(); //Empty the headers for the http web request
      myUsedControlLabels.Clear(); //Empty the used labels
      ConfiguredRunsLines.ToList().Clear(); //Empty ConfiguredRunsLines
      CustomURLBox.Clear(); //Empty the Custom URL Box
      #endregion

      #region TurnOff
      ClearButton.Visible = false; //Turn off the Clear Button
      RunRequest.Visible = false; //Turn off the Run Request Button.
      SaveRun.Visible = false; //Turn off the Save button
      ChooseFileButton.Visible = false; //Turn off the Load File button.
      tbFilePath.Visible = false; //Turn off the File Path text box.
      tbFilePath.Clear(); //Clear out the file path text boxes value.
      LoadButton.Visible = false; //Turn off the Load Button.
      CustomURLLabel.Visible = false; //Turn off CustomURL label
      CustomURLBox.Visible = false; //Turn off CustomURL button
      copyServiceButton.Visible = false; //Turn off CopyService Button
      #endregion

      if (GetInputsButton.Visible == false) { //Turn GetInputs back on
        GetInputsButton.Visible = true;
      }
      
      ServiceDropDown.Enabled = true; //Make the servicedropdown not greyed out if it was.

      //Refresh the screen for good measure
      this.Refresh(); 
    }

    private void RunRequest_Click(object sender, EventArgs e)
    {
      //copy myUsedControlBoxes so it is not altered for future use if needed.
      List<TextBox> copyUsedControlBoxes = new List<TextBox>(myUsedControlBoxes);
      List<string> copyUsedURLHeaders = new List<string>(myUsedURLHeaders);

      //remove textboxes whose contents is blank.
      for (int i = 0; i < copyUsedControlBoxes.Count; i++) {
        if (copyUsedControlBoxes[i].Text == "") {
          copyUsedControlBoxes.RemoveAt(i);
          copyUsedURLHeaders.RemoveAt(i);
        }
      }
      
      #region FormatInputs
      for (int i = 0; i < copyUsedControlBoxes.Count; i++) {
        if (copyUsedControlBoxes[i].Name == myLabels[0]) { //If the Name is returnJson
          copyUsedControlBoxes[i].Text = copyUsedControlBoxes[i].Text.ToLower(); //Make it lowercase
        }
      }
      #endregion

      //Are we using a custom URL??
      if (CustomURLBox.Text != "") {
        ServiceDropDown.Enabled = false;
        URLText = CustomURLBox.Text;
      }
      else {
        URLText = ServiceDropDown.Text;
      }

      //Create the URL for the get web request
      if (theGets.Contains(ServiceDropDown.Text)) {
        httpWebRequestURLSent = URLText + "?" + copyUsedURLHeaders[0] + "=" + copyUsedControlBoxes[0].Text;
        if (mTestPassesIfContains.Text == ""){
          for (int i = 1; i < copyUsedURLHeaders.Count; i++) {
            httpWebRequestURLSent = httpWebRequestURLSent + "&" + copyUsedURLHeaders[i] + "=" + copyUsedControlBoxes[i].Text;
          }
        }
        else {
          for (int i = 1; i < (copyUsedURLHeaders.Count-1); i++) {
            httpWebRequestURLSent = httpWebRequestURLSent + "&" + copyUsedURLHeaders[i] + "=" + copyUsedControlBoxes[i].Text;
          }
        }
      }//End Create URl for Get web requests

      //Create the info for the Post web request.
      if (thePosts.Contains(ServiceDropDown.Text)) {
        httpWebRequestURLSent = URLText;
        if (mTestPassesIfContains.Text == "") {
          for (int i = 0; i < copyUsedURLHeaders.Count; i++) {
            postData[copyUsedURLHeaders[i]] = copyUsedControlBoxes[i].Text;
          }
        }
        else {
          for (int i = 0; i < (copyUsedURLHeaders.Count-1); i++) {
            postData[copyUsedURLHeaders[i]] = copyUsedControlBoxes[i].Text;
          }
        }
      }


      //Double Check that returnJson was used or return no.
      if (mreturnjson.Text == "") {
        mreturnjson.Text = "no";
      }

      WebRequestResultsForm TTSResults = new WebRequestResultsForm(mreturnjson.Text.ToLower(), httpWebRequestURLSent, postData, mTestPassesIfContains.Text); 
      TTSResults.Show();
    }

    private void SaveRun_Click(object sender, EventArgs e)
    {
      try {
        List<string> SaveRun = new List<string>();
        for (int i = 0; i < myUsedControlBoxes.Count; i++) {
          SaveRun.Add(myUsedControlBoxes[i].Text);
        }
        File.WriteAllLines(myFilePath + myFileDictionary[ServiceDropDown.Text] + ".txt", SaveRun.ToArray(), Encoding.UTF8);
      }
      catch {
        List<string> SaveRun = new List<string>();
        for (int i = 0; i < myUsedControlBoxes.Count; i++) {
          SaveRun.Add("");
        }
        File.WriteAllLines(myFilePath + myFileDictionary[ServiceDropDown.Text] + ".txt", SaveRun.ToArray(), Encoding.UTF8);
      }
    }

    private void ChooseFileButton_Click(object sender, EventArgs e)
    {
      //Place and turn on File Path textbox.
      tbFilePath.Visible = true;
      tbFilePath.Location = new Point(ChooseFileButton.Location.X, ChooseFileButton.Location.Y + 30);

      //Place and turn on Load Button.
      LoadButton.Visible = true;
      LoadButton.Location = new Point(tbFilePath.Location.X + tbFilePath.Size.Width + 3, tbFilePath.Location.Y);
      
      //FileBrowse Method
      LoadNewFile();
    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
      try {
        if (System.IO.File.ReadAllLines(tbFilePath.Text).Count() == myUsedControlBoxes.Count) {
          string [] LoadedLines = System.IO.File.ReadAllLines(tbFilePath.Text);
          for (int i = 0; i < myUsedControlBoxes.Count; i++) {
            try {
              myUsedControlBoxes[i].Text = LoadedLines[i];
            }
            catch {
              myUsedControlBoxes[i].Text = "";
            }
          }
        }

        else {
          MessageBox.Show("Your selected file input doesn't match for the current request.\r\nYour selected file has " + (System.IO.File.ReadAllLines(tbFilePath.Text).Count()).ToString() + " elements and this request requires " + (myUsedControlBoxes.Count).ToString() + " elements.\r\nPlease update your request, File or choose a new file.");
        }
      }

      catch { }
    }

    private void copyServiceButton_Click(object sender, EventArgs e)
    {
      CustomURLBox.Text = ServiceDropDown.Text;
    }
    #endregion
  }//End Class
}//End NameSpace
