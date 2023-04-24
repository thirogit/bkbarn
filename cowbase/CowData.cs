using System;

namespace cowbase
{
	/// <summary>
	/// Summary description for CowData.
	/// </summary>
	public class Cow
	{
		public Cow()
		{
			EAN = String.Empty;
			sex = CowSex.NONE;
			weight = 0.0;
			myprice = null;
			stock = null;
			action = Action.FRESH;
            outgrp = SQLDB.NULL_OUT_GRP;
            termbuyprice = null;
            termbuyweight = null;
            termbuystock = null;
            termsellprice = null;
            termsellweight = null;
            termsellstock = null;
            hasBuyInv = false;
            ingrp = SQLDB.NULL_OUT_GRP;
		}
        /*
		Cow Clone()
		{
			Cow cow = new Cow();
			cow.EAN = this.EAN;
			cow.sex = this.sex;
			cow.weight = this.weight;
			cow.myprice = this.myprice;
			cow.stock = this.stock;
			cow.action = this.action;
			cow.outgrp = this.outgrp;
            cow.termbuyprice = this.termbuyprice;
            cow.termbuyweight = this.termbuyweight;
            cow.termbuystock = this.termbuystock;
            cow.termsellprice = this.termsellprice;
            cow.termsellweight = this.termsellweight;
            cow.termsellstock = this.termsellstock;
            cow.hasBuyInv = this.hasBuyInv;
            cow.ingrp = this.ingrp;
			return cow;
		}*/

        public CowSex sex;
		public string EAN;       
		public double weight;
		public Nullable<double> myprice;
		public Stock stock;
		public Action action;
		public int outgrp;
        public int ingrp;
		public int hentid;
		public string hentalias;
        public Nullable<double> termbuyprice;
        public Nullable<double> termbuyweight;
        public Nullable<int> termbuystock;
        public Nullable<double> termsellprice;
        public Nullable<double> termsellweight;
        public Nullable<int> termsellstock;
        public bool hasBuyInv;

        public override string ToString()
        {
            return "Cow = {" +
                "EAN = " + EAN +
                ", sex = " + sex.ToString() +
                ", weight = " + weight +
                ", myprice = " + myprice.ToString() +
                ", stock = " + stock +
                ", outgrp = " + outgrp +
                ", ingrp = " + ingrp +
                ", hentid = " + hentid +
                ", hentalias = " + hentalias +
                ", termbuyprice = " + termbuyprice.ToString() +
                ", termbuyweight = " + termbuyweight.ToString() +
                ", termbuystock = " + termbuystock +
                ", termsellprice = " + termsellprice.ToString() +
                ", termsellprice = " + termsellprice.ToString() +
                ", termsellweight = " + termsellweight.ToString() +
                ", termsellstock = " + termsellstock +
                ", hasBuyInv = " + hasBuyInv.ToString() +
                ", action = " + action.ToString() +
                "}";
        }
	}
}
