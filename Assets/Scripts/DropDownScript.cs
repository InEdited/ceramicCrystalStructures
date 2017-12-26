using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DropDownScript : MonoBehaviour {

    public Dropdown cationsDropdown;
    public Dropdown anionsDropdown;
    // drag the dropdop object into this reference in the inspector
    public GameObject[] cations;
    public GameObject[] anions;
    public Camera cameraTriagonal;
    public Camera cameraTetrahedral;
    public Camera cameraOctahedral;
    public Camera cameraCubic;
	public Camera cameraLinear;
    public double anion,cation;

	private readonly Dictionary <string,double> CationDatabase = new Dictionary<string,double> (){
		{"Choose an Anion",0},
		{"O2-",126},
		{"S2-",170},
		{"Se2-",184},
		{"Te2-",207},
		{"F-",119},
		{"Cl-",167},
		{"Br-",182},
		{"I-",206},
	};
	private Dictionary<string, double> AnionDatabase = new Dictionary<string, double>()
{
		{"Choose a Cation", 0},
     {"Li+",90},
     {"Na+",116},
     {"K+",152},
     {"Cu+",91},
     {"Rb+",166},
     {"Ag+",129},
     {"Cs+",181},
     {"Au+",151},
     {"Hg+",133},
     {"Tl+",164},
     {"Fr+",194},
     {"Be2+",59},
     {"Mg2+",86},
     {"Ca2+",114},
     {"Ti2+",100},
     {"V2+",3},
     {"Cr2+",90.5},
     {"Mn2+",89},
     {"Fe2+",83.5},
     {"Co2+",83.8},
     {"Ni2+",83},
     {"Cu2+",87},
     {"Zn2+",88},
     {"Ge2+",87},
     {"Sr2+",132},
     {"Pd2+",100},
     {"Ag2+",108},
     {"Cd2+",109},
     {"Ba2+",149},
     {"Eu2+",131},
     {"Dy2+",121},
     {"Tm2+",117},
     {"Yb2+",116},
     {"Pt2+",94},
     {"Hg2+",116},
     {"Pb2+",133},
     {"Ra2+",162},
     {"Np2+",124},
     {"No2+",124},
     {"B3+",41},
     {"N3+",30},
     {"Al3+",67.5},
     {"P3+",58},
     {"Sc3+",88.5},
     {"Ti3+",81},
     {"V3+",78},
     {"Cr3+",75.5},
     {"Mn3+",75.3},
     {"Fe3+",73.8},
     {"Co3+",71.8},
     {"Ni3+",72},
     {"Cu3+",68},
     {"Ga3+",76},
     {"As3+",72},
     {"Y3+",104},
     {"Nb3+",86},
     {"Mo3+",83},
     {"Ru3+",82},
     {"Rh3+",80.5},
     {"Pd3+",90},
     {"Ag3+",89},
     {"In3+",94},
     {"Sb3+",90},
     {"La3+",117.2},
     {"Ce3+",115},
     {"Pr3+",113},
     {"Nd3+",112.3},
     {"Pm3+",111},
     {"Sm3+",109.8},
     {"Eu3+",108.7},
     {"Gd3+",107.8},
     {"Tb3+",106.3},
     {"Dy3+",105.2},
     {"Ho3+",104.1},
     {"Er3+",103},
     {"Tm3+",102},
     {"Yb3+",100.8},
     {"Lu3+",100.1},
     {"Ta3+",86},
     {"Ir3+",82},
     {"Au3+",99},
     {"Tl3+",102.5},
     {"Bi3+",117},
     {"Ac3+",126},
     {"Pa3+",118},
     {"U3+",116.5},
     {"Np3+",115},
     {"Pu3+",114},
     {"Am3+",111.5},
     {"Cm3+",111},
     {"Bk3+",110},
     {"Cf3+",109}
};

    private void FixedUpdate()
    {
        changeCamera(anion,cation);
    }

    private void Start()
    {
        cations = GameObject.FindGameObjectsWithTag("cation");
        anions = GameObject.FindGameObjectsWithTag("anion");
    }
    public void DropdownCationValueChanged(int newPosition)
    {
		double ion1 = CationDatabase.Values.ElementAt((int)newPosition);
		cation = ion1;
        //double ion2 = IonsDatabase.Values.ElementAt((int)newPosition);
        //print(ion1);
        foreach (GameObject cation in cations)
        {
            Vector3 mi = transform.localScale;
            mi.y = (float) ion1/200;
            mi.x = (float) ion1/200;
            mi.z = (float) ion1/200;
			cation.transform.localScale = mi;
            //cation.transform.lossyScale
        }
}
    public void DropdownAnionValueChanged(int newPosition)
    {
        //double ion1 = IonsDatabase.Values.ElementAt((int)newPosition); 
		double ion2 = AnionDatabase.Values.ElementAt((int)newPosition); 
		anion = ion2;
        //print(ion2);
		foreach (GameObject anion in anions)
        {
            Vector3 mi = transform.localScale;
            mi.y = (float)ion2 / 200;
            mi.x = (float)ion2 / 200;
            mi.z = (float)ion2 / 200;
			anion.transform.localScale = mi;
            //cation.transform.lossyScale
        }

    }

    private void Awake()
    {
        if (cationsDropdown != null)
        {
            cationsDropdown.ClearOptions();
			cationsDropdown.AddOptions(CationDatabase.Keys.ToList());

            cationsDropdown.onValueChanged.AddListener(DropdownCationValueChanged);
        }
        if (anionsDropdown != null)
        {
            anionsDropdown.ClearOptions();
			anionsDropdown.AddOptions(AnionDatabase.Keys.ToList());

            anionsDropdown.onValueChanged.AddListener(DropdownAnionValueChanged);
        }
    }

    private void changeCamera(double cation , double anion)
    {
        double ratio = (double)cation / (double)anion;
        print(cation);
        print(anion);
        print(ratio);
		if (ratio<=0.15)
		{
			cameraLinear.depth = 0;
			cameraTriagonal.depth = -1;
            cameraOctahedral.depth = -1;
            cameraTetrahedral.depth = -1;
            cameraCubic.depth = -1;
		}
        else if (ratio >= 0.15 && ratio <= 0.225)
        {
			cameraLinear.depth = -1;
            cameraTriagonal.depth = 0;
            cameraOctahedral.depth = -1;
            cameraTetrahedral.depth = -1;
            cameraCubic.depth = -1;
        } //triagonal
        else if (ratio >= 0.2255 && ratio <= 0.414)
        {
			cameraLinear.depth = -1;
            cameraTriagonal.depth = -1;
            cameraOctahedral.depth = -1;
            cameraTetrahedral.depth = 0;
            cameraCubic.depth = -1;
        } //tetrahedral
        else if (ratio >= 0.414 && ratio <= 0.73)
        {
			cameraLinear.depth = -1;
            cameraTriagonal.depth = -1;
            cameraOctahedral.depth = 0;
            cameraTetrahedral.depth = -1;
            cameraCubic.depth = -1;
        } //octahedral
        else if (ratio >= 0.73 && ratio <= 1)
        {
			cameraLinear.depth = -1;
            cameraTriagonal.depth = -1;
            cameraOctahedral.depth = -1;
            cameraTetrahedral.depth = -1;
            cameraCubic.depth = 0;
        } //cubic
    }

    //private void DropdownValueChanged(int newPosition)
    //{
      //  double realValue = IonsDatabase.Values.ElementAt(newPosition);
        // realValue is the integer value associated with this key index
        // do whatever you need to do with it here
    //}
}