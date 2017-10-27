function getReceipt() {
	string1 = "";
	string2 = "";
	var runningTotal = 0;
	var sizeTotal = 0;
	var sizeArray = document.getElementsByClassName("size");
	for (var i = 0; i < sizeArray.length; i++) {
		if (sizeArray[i].checked) {
			var selectedSize = sizeArray[i].value;
			string1 = string1+selectedSize+"<br>";
		}
	}
	if (selectedSize === "Personal Pizza") {
		sizeTotal = 6;
		string2 = string2+sizeTotal+"<br>";
	} else if (selectedSize === "Medium Pizza") {
		sizeTotal = 10;
		string2 = string2+sizeTotal+"<br>";
	} else if (selectedSize === "Large Pizza") {
		sizeTotal = 14;
		string2 = string2+sizeTotal+"<br>";
	} else if (selectedSize === "Extra Large Pizza") {
		sizeTotal = 16;
		string2 = string2+sizeTotal+"<br>";
	}
	runningTotal = sizeTotal;
	getMeat(runningTotal,string1,string2);1
};

function getMeat(runningTotal,string1,string2) {
	var runningTotal = runningTotal;
	var meatTotal = 0;
	var meatChoice = [];
	var meatArray = document.getElementsByClassName("meats");
	for (var j = 0; j < meatArray.length; j++) {
		if (meatArray[j].checked) {
			meatChoice.push(meatArray[j].value);
		}
	}
	var meatCount = meatChoice.length;
	if (meatCount > 1) {
		meatTotal = (meatCount - 1);
	} else {
		meatTotal = 0;
	}
	runningTotal = (runningTotal + meatTotal);
	for (var j = 0; j < meatChoice.length; j++) {
			string1 = string1+meatChoice[j]+"<br>";
			if (meatCount <= 1) {
				string2 = string2 + 0 + "<br>";
				meatCount = meatCount - 1;
			} else if (meatCount == 2) {
				string2 = string2 + 1 + "<br>";
				meatCount = meatCount - 1;
			} else {
				string2 = string2 + 1 + "<br>";
				meatCount = meatCount - 1;
			}
	}
	getVeggie(runningTotal,string1,string2);
};

function getVeggie(runningTotal,string1,string2) {
	var veggieTotal = 0;
	var veggieChoice = [];
	var veggieArray = document.getElementsByClassName("veggies");
	for (var j = 0; j < veggieArray.length; j++) {
		if (veggieArray[j].checked) {
			veggieChoice.push(veggieArray[j].value);
		}
	}
	var veggieCount = veggieChoice.length;
	if (veggieCount >= 2) {
		veggieTotal = (veggieCount - 1);
	} else {
		veggieTotal = 0;
	}
	runningTotal = (runningTotal + veggieTotal);
	for (var j = 0; j < veggieChoice.length; j++) {
			string1 = string1+veggieChoice[j]+"<br>";
			if (veggieCount <= 1) {
				string2 = string2 + 0 + "<br>";
				veggieCount = veggieCount - 1;
			} else if (veggieCount == 2) {
				string2 = string2 + 1 + "<br>";
				veggieCount = veggieCount - 1;
			} else {
				string2 = string2 + 1 + "<br>";
				veggieCount = veggieCount - 1;
			}
	}
	getCheese(runningTotal,string1,string2);
};

function getCheese(runningTotal,string1,string2) {
	var cheeseTotal = 0;
	var cheeseChoice = [];
	var cheeseArray = document.getElementsByClassName("cheese");
	for (var j = 0; j < cheeseArray.length; j++) {
		if (cheeseArray[j].checked) {
			cheeseChoice = cheeseArray[j].value;
		}
		if (cheeseChoice === "Extra cheese") {
			cheeseTotal = 3;
		}
	}
	string2 = string2+cheeseTotal+"<br>";
	string1 = string1+cheeseChoice+"<br>";
	runningTotal = (runningTotal + cheeseTotal);
	getSauce(runningTotal,string1,string2);
};

function getSauce(runningTotal,string1,string2) {
	var sauceArray = document.getElementsByClassName("sauce");
	for (var j = 0; j < sauceArray.length; j++) {
		if (sauceArray[j].checked) {
			selectedSauce = sauceArray[j].value;
			string1 = string1 + selectedSauce +"<br>";
		}
	}
	string2 = string2 + 0 + "<br>";
	getCrust(runningTotal,string1,string2)
};

function getCrust(runningTotal,string1,string2) {
	var crustTotal = 0;
	var crustChoice;
	var crustArray = document.getElementsByClassName("crust");
	for (var j = 0; j < crustArray.length; j++) {
		if (crustArray[j].checked) {
			crustChoice = crustArray[j].value;
			string1 = string1 + crustChoice + "<br>";
		}
		if (crustChoice === "Cheese Stuffed Crust") {
			crustTotal = 3;
		}
	}
	runningTotal = (runningTotal + crustTotal);
	string2 = string2 + crustTotal + "<br>";
	document.getElementById("cart").style.opacity=1;
	document.getElementById("showString1").innerHTML=string1;
	document.getElementById("showString2").innerHTML=string2;
	document.getElementById("totalPrice2").innerHTML = "</h2>$"+runningTotal+".00"+"</h2>";
};

function clearAll() {
	document.getElementById("frmMenu").reset();
	document.getElementById("cart").style.opacity=0;
};