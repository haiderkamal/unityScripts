using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using System.Globalization;
public class DataLoader : MonoBehaviour
{
    /*
    public int playerID = 1;
   
    public string[] poss;
    public Text mulplayer; 
    public string mulplayerrr,hello;
    public float x;
    public string y,yy;
    public int z;
    public int score = 0,number = 0;
    


    public Text NextHighScore;
    public Text NextHighScorename;
    public Image country;
    public Dropdown m_Dropdown;
    public Dropdown m_Dropdown2;

    public Sprite[] flags;
    public string flagName = "";
    public string countrySelected;
    public float[] Lscore;
    public string[] Lname, Lcountry;



    string url = "http://sourcehouse.org/www/getplayerdata.php";
    string urlLeaderBoard = "http://sourcehouse.org/www/getleaderboard.php";


    Coroutine m_MyCoroutineReference;
    Coroutine m_MyCoroutineReference_leaderboard;
    
    List<string> m_DropOptions = new List<string>() {"Afghanistan",
"Albania",
"Algeria",
"AmericanSamoa",
"Andorra",
"Angola",
"Anguilla",
"Antigua&Barbuda",
"Argentina",
"Armenia",
"Aruba",
"Australia",
"Austria",
"Azerbaijan",
"BahamasThe",
"Bahrain",
"Bangladesh",
"Barbados",
"Belarus",
"Belgium",
"Belize",
"Benin",
"Bermuda",
"Bhutan",
"Bolivia",
"Bosnia&Herzegovina",
"Botswana",
"Brazil",
"BritishVirginIs",
"Brunei",
"Bulgaria",
"BurkinaFaso",
"Burma",
"Burundi",
"Cambodia",
"Cameroon",
"Canada",
"CapeVerde",
"CaymanIslands",
"CentralAfricanRep",
"Chad",
"Chile",
"China",
"Colombia",
"Comoros",
"CongoDemRep",
"CongoRepubofthe",
"CookIslands",
"CostaRica",
"Coted'Ivoire",
"Croatia",
"Cuba",
"Cyprus",
"CzechRepublic",
"Denmark",
"Djibouti",
"Dominica",
"DominicanRepublic",
"EastTimor",
"Ecuador",
"Egypt",
"ElSalvador",
"EquatorialGuinea",
"Eritrea",
"Estonia",
"Ethiopia",
"FaroeIslands",
"Fiji",
"Finland",
"France",
"FrenchGuiana",
"FrenchPolynesia",
"Gabon",
"GambiaThe",
"GazaStrip",
"Georgia",
"Germany",
"Ghana",
"Gibraltar",
"Greece",
"Greenland",
"Grenada",
"Guadeloupe",
"Guam",
"Guatemala",
"Guernsey",
"Guinea",
"GuineaBissau",
"Guyana",
"Haiti",
"Honduras",
"HongKong",
"Hungary",
"Iceland",
"India",
"Indonesia",
"Iran",
"Iraq",
"Ireland",
"IsleofMan",
"Israel",
"Italy",
"Jamaica",
"Japan",
"Jersey",
"Jordan",
"Kazakhstan",
"Kenya",
"Kiribati",
"KoreaNorth",
"KoreaSouth",
"Kuwait",
"Kyrgyzstan",
"Laos",
"Latvia",
"Lebanon",
"Lesotho",
"Liberia",
"Libya",
"Liechtenstein",
"Lithuania",
"Luxembourg",
"Macau",
"Macedonia",
"Madagascar",
"Malawi",
"Malaysia",
"Maldives",
"Mali",
"Malta",
"MarshallIslands",
"Martinique",
"Mauritania",
"Mauritius",
"Mayotte",
"Mexico",
"MicronesiaFedSt",
"Moldova",
"Monaco",
"Mongolia",
"Montserrat",
"Morocco",
"Mozambique",
"Namibia",
"Nauru",
"Nepal",
"Netherlands",
"NetherlandsAntilles",
"NewCaledonia",
"NewZealand",
"Nicaragua",
"Niger",
"Nigeria",
"NMarianaIslands",
"Norway",
"Oman",
"Pakistan",
"Palau",
"Panama",
"PapuaNewGuinea",
"Paraguay",
"Peru",
"Philippines",
"Poland",
"Portugal",
"PuertoRico",
"Qatar",
"Reunion",
"Romania",
"Russia",
"Rwanda",
"SaintHelena",
"SaintKitts&Nevis",
"SaintLucia",
"StPierre&Miquelon",
"SaintVincentandtheGrenadines",
"Samoa",
"SanMarino",
"SaoTome&Principe",
"SaudiArabia",
"Senegal",
"Serbia",
"Seychelles",
"SierraLeone",
"Singapore",
"Slovakia",
"Slovenia",
"SolomonIslands",
"Somalia",
"SouthAfrica",
"Spain",
"SriLanka",
"Sudan",
"Suriname",
"Swaziland",
"Sweden",
"Switzerland",
"Syria",
"Taiwan",
"Tajikistan",
"Tanzania",
"Thailand",
"Togo",
"Tonga",
"Trinidad&Tobago",
"Tunisia",
"Turkey",
"Turkmenistan",
"Turks&CaicosIs",
"Tuvalu",
"Uganda",
"Ukraine",
"UnitedArabEmirates",
"UnitedKingdom",
"UnitedStates",
"Uruguay",
"Uzbekistan",
"Vanuatu",
"Venezuela",
"Vietnam",
"VirginIslands",
"WallisandFutuna",
"WestBank",
"WesternSahara",
"Yemen",
"Zambia",
"Zimbabwe",


};
       
     void Start()
        {
        z = 0;
            populateList();

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("no Internet");
        }
        else
        {
            m_MyCoroutineReference = StartCoroutine("Retrieve");
            m_MyCoroutineReference_leaderboard = StartCoroutine("RetrieveLeaderBoard");
           
        }
        Invoke("starterFun", 2f);
        Invoke("starterFun", 4f);

       
    }
    public void starterFUn()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("no Internet");
        }
        else
        {
            m_MyCoroutineReference = StartCoroutine("Retrieve");
            m_MyCoroutineReference_leaderboard = StartCoroutine("RetrieveLeaderBoard");
            
        }
    }
     public void showLeaderBoard()
     {
         if (Application.internetReachability == NetworkReachability.NotReachable)
         {
             Debug.Log("no Internet");
         }
         else
         {
             StopCoroutine(m_MyCoroutineReference_leaderboard);
             StartCoroutine("RetrieveLeaderBoard");
         }
     }
     public void dropdownIndexValue(int index)
     {
         PlayerPrefs.SetString("country", m_DropOptions[index]);
         Debug.Log(m_DropOptions[index]);
     }
     public void populateList()
     {
         m_Dropdown.AddOptions(m_DropOptions);
         
        }
     void PopulateDropdown(Dropdown dropdown, string[] optionsArray)
     {
         List<string> options = new List<string>();
         foreach (var option in optionsArray)
         {
             options.Add(option); // Or whatever you want for a label
         }
         dropdown.ClearOptions();
         dropdown.AddOptions(options);
     }
    
    public void retrievee(int scoreR)
    {
        score = scoreR;
       

        if (z<=1)
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("no Internet");
            }
            else
            {
                StopCoroutine(m_MyCoroutineReference);
                StartCoroutine("Retrieve");
            }
        }
        z = (int)x - score;
        if (z < 0)
        {
            z = 0;
        }
        NextHighScore.text = z.ToString();

    }

    public IEnumerator RetrieveLeaderBoard()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("no Internet");
        }
        else
        {
            var form2 = new WWWForm();
            form2.headers.Clear();

            Debug.Log("submitting " + form2 + " to " + urlLeaderBoard + "Score: " + score);
            Debug.Log(form2);
            Debug.Log(score);
            form2.AddField("mulPlayPost", score);

            WWW request = new WWW(urlLeaderBoard, form2);
            yield return request;

            while (!string.IsNullOrEmpty(request.error))
            {
                Debug.Log(request + " error:\n" + request.error);
            }


            Debug.Log("Sent " + request + " successfully, result:\n" + request.text);
            poss = request.text.Split(';');
         
            for (int i = 0; i < poss.Length; i ++)
            {
                Lname[i] = poss[i];
                Debug.Log(Lname[i]);
            }
            PopulateDropdown(m_Dropdown2, Lname);


       
            Debug.Log("This function is also called");

            yield return null;
           
        }
    }

   

   
    public IEnumerator Retrieve()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("no Internet");
        }
        else
        {
            var form = new WWWForm();
            form.headers.Clear();
            form.headers.Remove("score");
            form.AddField("mulPlayPost", score);
            Debug.Log("submitting " + form + " to " + url + "Score: " + score);
            Debug.Log(form);
            Debug.Log(score);

            WWW request = new WWW(url, form);
            yield return request;

            while (!string.IsNullOrEmpty(request.error))
            {
                Debug.Log(request + " error:\n" + request.error);
            }


            Debug.Log("Sent " + request + " successfully, result:\n" + request.text);
            poss = request.text.Split(';');
            x = float.Parse(poss[0], new CultureInfo("en-US").NumberFormat);
            Debug.Log(x);
            y = poss[1];
            yy = poss[2];
            Debug.Log(y);
            Debug.Log(yy);
            NextHighScore.text = (x - score).ToString();
            NextHighScorename.text = y.ToString();

           // mulplayer.text = x.ToString();
            Change_Country(yy);
            yield return null;
        }
    }
    void update()
    {
      
    }

    void dropdown()
    {
       
    }

    public void Change_Country(string Rcountry)
    {
        switch (Rcountry)
        {
            case "Afghanistan":
                country.sprite = flags[0];
                break;
            case "Albania":
                country.sprite = flags[1];
                break;
            case "Algeria":
                country.sprite = flags[2];
                break;
            case "AmericanSamoa":
                country.sprite = flags[3];
                break;
            case "Andorra":
                country.sprite = flags[4];
                break;
            case "Angola":
                country.sprite = flags[5];
                break;
            case "Anguilla":
                country.sprite = flags[6];
                break;
            case "Antigua&Barbuda":
                country.sprite = flags[7];
                break;
            case "Argentina":
                country.sprite = flags[8];
                break;
            case "Armenia":
                country.sprite = flags[9];
                break;
            case "Aruba":
                country.sprite = flags[10];
                break;
            case "Australia":
                country.sprite = flags[11];
                break;
            case "Austria":
                country.sprite = flags[12];
                break;
            case "Azerbaijan":
                country.sprite = flags[13];
                break;
            case "BahamasThe":
                country.sprite = flags[14];
                break;
            case "Bahrain":
                country.sprite = flags[15];
                break;
            case "Bangladesh":
                country.sprite = flags[16];
                break;
            case "Barbados":
                country.sprite = flags[17];
                break;
            case "Belarus":
                country.sprite = flags[18];
                break;
            case "Belgium":
                country.sprite = flags[19];
                break;
            case "Belize":
                country.sprite = flags[20];
                break;
            case "Benin":
                country.sprite = flags[21];
                break;
            case "Bermuda":
                country.sprite = flags[22];
                break;
            case "Bhutan":
                country.sprite = flags[23];
                break;
            case "Bolivia":
                country.sprite = flags[24];
                break;
            case "Bosnia&Herzegovina":
                country.sprite = flags[25];
                break;
            case "Botswana":
                country.sprite = flags[26];
                break;
            case "Brazil":
                country.sprite = flags[27];
                break;
            case "BritishVirginIs":
                country.sprite = flags[28];
                break;
            case "Brunei":
                country.sprite = flags[29];
                break;
            case "Bulgaria":
                country.sprite = flags[30];
                break;
            case "BurkinaFaso":
                country.sprite = flags[31];
                break;
            case "Burma":
              country.sprite = flags[32];
            break;
            case "Burundi":
                country.sprite = flags[33];
                break;
            case "Cambodia":
                country.sprite = flags[34];
                break;
            case "Cameroon":
                country.sprite = flags[35];
                break;
            case "Canada":
                country.sprite = flags[36];
                break;
            case "CapeVerde":
                country.sprite = flags[37];
                break;
            case "CaymanIslands":
                country.sprite = flags[38];
                break;
            case "CentralAfricanRep":
                country.sprite = flags[39];
                break;
            case "Chad":
                country.sprite = flags[40];
                break;
            case "Chile":
                country.sprite = flags[41];
                break;
            case "China":
                country.sprite = flags[42];
                break;
            case "Colombia":
                country.sprite = flags[43];
                break;
            case "Comoros":
                country.sprite = flags[44];
                break;
            case "CongoDemRep":
                country.sprite = flags[45];
                break;
            case "CongoRepubofthe":
                country.sprite = flags[46];
                break;
            case "CookIslands":
                country.sprite = flags[47];
                break;
            case "CostaRica":
                country.sprite = flags[48];
                break;
            case "CotedIvoire":
                country.sprite = flags[49];
                break;
            case "Croatia":
                country.sprite = flags[50];
                break;
            case "Cuba":
                country.sprite = flags[51];
                break;
            case "Cyprus":
                country.sprite = flags[52];
                break;
            case "CzechRepublic":
                country.sprite = flags[53];
                break;
            case "Denmark":
                country.sprite = flags[54];
                break;
            case "Djibouti":
                country.sprite = flags[55];
                break;
            case "Dominica":
                country.sprite = flags[56];
                break;
            case "DominicanRepublic":
                country.sprite = flags[57];
                break;
            case "EastTimor":
                country.sprite = flags[58];
                break;
            case "Ecuador":
                country.sprite = flags[59];
                break;
            case "Egypt":
                country.sprite = flags[60];
                break;
            case "ElSalvador":
                country.sprite = flags[61];
                break;
            case "EquatorialGuinea":
                country.sprite = flags[62];
                break;
            case "Eritrea":
                country.sprite = flags[63];
                break;
            case "Estonia":
                country.sprite = flags[64];
                break;
            case "Ethiopia":
                country.sprite = flags[65];
                break;
            case "FaroeIslands":
                country.sprite = flags[66];
                break;
            case "Fiji":
                country.sprite = flags[67];
                break;
            case "Finland":
                country.sprite = flags[68];
                break;
            case "France":
                country.sprite = flags[69];
                break;
            case "FrenchGuiana":
                country.sprite = flags[70];
                break;
            case "FrenchPolynesia":
                country.sprite = flags[71];
                break;
            case "Gabon":
                country.sprite = flags[72];
                break;
            case "GambiaThe":
                country.sprite = flags[73];
                break;
            case "GazaStrip":
                country.sprite = flags[74];
                break;
            case "Georgia":
                country.sprite = flags[75];
                break;
            case "Germany":
                country.sprite = flags[76];
                break;
            case "Ghana":
                country.sprite = flags[77];
                break;
            case "Gibraltar":
                country.sprite = flags[78];
                break;
            case "Greece":
                country.sprite = flags[79];
                break;
            case "Greenland":
                country.sprite = flags[80];
                break;
            case "Grenada":
                country.sprite = flags[81];
                break;
            case "Guadeloupe":
                country.sprite = flags[82];
                break;
            case "Guam":
                country.sprite = flags[83];
                break;
            case "Guatemala":
                country.sprite = flags[84];
                break;
            case "Guernsey":
                country.sprite = flags[85];
                break;
            case "Guinea":
                country.sprite = flags[86];
                break;
            case "GuineaBissau":
                country.sprite = flags[87];
                break;
            case "Guyana":
                country.sprite = flags[88];
                break;
            case "Haiti":
                country.sprite = flags[89];
                break;
            case "Honduras":
                country.sprite = flags[90];
                break;
            case "HongKong":
                country.sprite = flags[91];
                break;
            case "Hungary":
                country.sprite = flags[92];
                break;
            case "Iceland":
                country.sprite = flags[93];
                break;
            case "India":
                country.sprite = flags[94];
                break;
            case "Indonesia":
                country.sprite = flags[95];
                break;
            case "Iran":
                country.sprite = flags[96];
                break;
            case "Iraq":
                country.sprite = flags[97];
                break;
            case "Ireland":
                country.sprite = flags[98];
                break;
            case "IsleofMan":
                country.sprite = flags[99];
                break;
            case "Israel":
                country.sprite = flags[100];
                break;
            case "Italy":
                country.sprite = flags[101];
                break;
            case "Jamaica":
                country.sprite = flags[102];
                break;
            case "Japan":
                country.sprite = flags[103];
                break;
            case "Jersey":
                country.sprite = flags[104];
                break;
            case "Jordan":
                country.sprite = flags[105];
                break;
            case "Kazakhstan":
                country.sprite = flags[106];
                break;
            case "Kenya":
                country.sprite = flags[107];
                break;
            case "Kiribati":
                country.sprite = flags[108];
                break;
            case "KoreaNorth":
                country.sprite = flags[109];
                break;
            case "KoreaSouth":
                country.sprite = flags[110];
                break;
            case "Kuwait":
                country.sprite = flags[111];
                break;
            case "Kyrgyzstan":
                country.sprite = flags[112];
                break;
            case "Laos":
                country.sprite = flags[113];
                break;
            case "Latvia":
                country.sprite = flags[114];
                break;
            case "Lebanon":
                country.sprite = flags[115];
                break;
            case "Lesotho":
                country.sprite = flags[116];
                break;
            case "Liberia":
                country.sprite = flags[117];
                break;
            case "Libya":
                country.sprite = flags[118];
                break;
            case "Liechtenstein":
                country.sprite = flags[119];
                break;
            case "Lithuania":
                country.sprite = flags[120];
                break;
            case "Luxembourg":
                country.sprite = flags[121];
                break;
            case "Macau":
                country.sprite = flags[122];
                break;
            case "Macedonia":
                country.sprite = flags[123];
                break;
            case "Madagascar":
                country.sprite = flags[124];
                break;
            case "Malawi":
                country.sprite = flags[125];
                break;
            case "Malaysia":
                country.sprite = flags[126];
                break;
            case "Maldives":
                country.sprite = flags[127];
                break;
            case "Mali":
                country.sprite = flags[128];
                break;
            case "Malta":
                country.sprite = flags[129];
                break;
            case "MarshallIslands":
                country.sprite = flags[130];
                break;
            case "Martinique":
                country.sprite = flags[131];
                break;
            case "Mauritania":
                country.sprite = flags[132];
                break;
            case "Mauritius":
                country.sprite = flags[133];
                break;
            case "Mayotte":
                country.sprite = flags[134];
                break;
            case "Mexico":
                country.sprite = flags[135];
                break;
            case "MicronesiaFedSt":
                country.sprite = flags[136];
                break;
            case "Moldova":
                country.sprite = flags[137];
                break;
            case "Monaco":
                country.sprite = flags[138];
                break;
            case "Mongolia":
                country.sprite = flags[139];
                break;
            case "Montserrat":
                country.sprite = flags[140];
                break;
            case "Morocco":
                country.sprite = flags[141];
                break;
            case "Mozambique":
                country.sprite = flags[142];
                break;
            case "Namibia":
                country.sprite = flags[143];
                break;
            case "Nauru":
                country.sprite = flags[144];
                break;
            case "Nepal":
                country.sprite = flags[145];
                break;
            case "Netherlands":
                country.sprite = flags[146];
                break;
            case "NetherlandsAntilles":
                country.sprite = flags[147];
                break;
            case "NewCaledonia":
                country.sprite = flags[148];
                break;
            case "NewZealand":
                country.sprite = flags[149];
                break;
            case "Nicaragua":
                country.sprite = flags[150];
                break;
            case "Niger":
                country.sprite = flags[151];
                break;
            case "Nigeria":
                country.sprite = flags[152];
                break;
            case "NMarianaIslands":
                country.sprite = flags[153];
                break;
            case "Norway":
                country.sprite = flags[154];
                break;
            case "Oman":
                country.sprite = flags[155];
                break;
            case "Pakistan":
                country.sprite = flags[156];
                break;
            case "Palau":
                country.sprite = flags[157];
                break;
            case "Panama":
                country.sprite = flags[158];
                break;
            case "PapuaNewGuinea":
                country.sprite = flags[159];
                break;
            case "Paraguay":
                country.sprite = flags[160];
                break;
            case "Peru":
                country.sprite = flags[161];
                break;
            case "Philippines":
                country.sprite = flags[162];
                break;
            case "Poland":
                country.sprite = flags[163];
                break;
            case "Portugal":
                country.sprite = flags[164];
                break;
            case "PuertoRico":
                country.sprite = flags[165];
                break;
            case "Qatar":
                country.sprite = flags[166];
                break;
            case "Reunion":
                country.sprite = flags[167];
                break;
            case "Romania":
                country.sprite = flags[168];
                break;
            case "Russia":
                country.sprite = flags[168];
                break;
            case "Rwanda":
                country.sprite = flags[169];
                break;
            case "SaintHelena":
                country.sprite = flags[170];
                break;
            case "SaintKitts&Nevis":
                country.sprite = flags[171];
                break;
            case "SaintLucia":
                country.sprite = flags[172];
                break;
            case "StPierre&Miquelon":
                country.sprite = flags[173];
                break;
            case "SaintVincentandtheGrenadines":
                country.sprite = flags[174];
                break;
            case "Samoa":
                country.sprite = flags[175];
                break;
            case "SanMarino":
                country.sprite = flags[176];
                break;
            case "SaoTome&Principe":
                country.sprite = flags[177];
                break;
            case "SaudiArabia":
                country.sprite = flags[178];
                break;
            case "Senegal":
                country.sprite = flags[179];
                break;
            case "Serbia":
                country.sprite = flags[180];
                break;
            case "Seychelles":
                country.sprite = flags[181];
                break;
            case "SierraLeone":
                country.sprite = flags[182];
                break;
            case "Singapore":
                country.sprite = flags[183];
                break;
            case "Slovakia":
                country.sprite = flags[184];
                break;
            case "Slovenia":
                country.sprite = flags[185];
                break;
            case "SolomonIslands":
                country.sprite = flags[186];
                break;
            case "Somalia":
                country.sprite = flags[187];
                break;
            case "SouthAfrica":
                country.sprite = flags[188];
                break;
            case "Spain":
                country.sprite = flags[189];
                break;
            case "SriLanka":
                country.sprite = flags[190];
                break;
            case "Sudan":
                country.sprite = flags[191];
                break;
            case "Suriname":
                country.sprite = flags[192];
                break;
            case "Swaziland":
                country.sprite = flags[193];
                break;
            case "Sweden":
                country.sprite = flags[194];
                break;
            case "Switzerland":
                country.sprite = flags[195];
                break;
            case "Syria":
                country.sprite = flags[196];
                break;
            case "Taiwan":
                country.sprite = flags[197];
                break;
            case "Tajikistan":
                country.sprite = flags[198];
                break;
            case "Tanzania":
                country.sprite = flags[199];
                break;
            case "Thailand":
                country.sprite = flags[200];
                break;
            case "Togo":
                country.sprite = flags[201];
                break;
            case "Tonga":
                country.sprite = flags[202];
                break;
            case "Trinidad&Tobago":
                country.sprite = flags[203];
                break;
            case "Tunisia":
                country.sprite = flags[204];
                break;
            case "Turkey":
                country.sprite = flags[205];
                break;
            case "Turkmenistan":
                country.sprite = flags[206];
                break;
            case "Turks&CaicosIs":
                country.sprite = flags[207];
                break;
            case "Tuvalu":
                country.sprite = flags[208];
                break;
            case "Uganda":
                country.sprite = flags[209];
                break;
            case "Ukraine":
                country.sprite = flags[210];
                break;
            case "UnitedArabEmirates":
                country.sprite = flags[211];
                break;
            case "UnitedKingdom":
                country.sprite = flags[212];
                break;
            case "UnitedStates":
                country.sprite = flags[213];
                break;
            case "Uruguay":
                country.sprite = flags[214];
                break;
            case "Uzbekistan":
                country.sprite = flags[215];
                break;
            case "Vanuatu":
                country.sprite = flags[216];
                break;
            case "Venezuela":
                country.sprite = flags[217];
                break;
            case "Vietnam":
                country.sprite = flags[218];
                break;
            case "VirginIslands":
                country.sprite = flags[219];
                break;
            case "WallisandFutuna":
                country.sprite = flags[220];
                break;
            case "WestBank":
                country.sprite = flags[221];
                break;
            case "WesternSahara":
                country.sprite = flags[222];
                break;
            case "Yemen":
                country.sprite = flags[223];
                break;
            case "Zambia":
                country.sprite = flags[224];
                break;
            case "Zimbabwe":
                country.sprite = flags[225];
                break;


        }
    }
    */
    
    
}