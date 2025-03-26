// dynamically type lang

var number;
console.log(typeof number);
number=1;
console.log(typeof number);
number="abc";
console.log(typeof number);
number=true;
console.log(typeof number);


let num2=67;
console.log(typeof num2);
num2="par";
console.log(typeof num2);


const num3=67;
console.log(typeof num3);

// we can redeclare var type variable
// we can reassign also. we can change value .

var companyname="neossoft";
var companyname="neosoft PVT";
companyname="neo";

// we can not redeclare var type variable
// we can reassign. we can change value.

let city="Thane";
// let city="Ghansoli";
city="Rabale";



function loop(){
    console.log(i);
    for(var i=1;i<=5;i++){
        console.log(i);
    }
    console.log("After Loop "+i);

    function test(){
        var year=2025;
        console.log(year);
        console.log(i);
    }
    
    test();
    // console.log(year);

}

loop();


function loop2(){
    //    console.log(i);     error : not defined 
    for(let i=1;i<=5;i++){
        console.log(i);
    }// for end i scope end
    //  console.log("after:"+i);  /* error : not defined */
}
loop2();


const addfun=function(num1,num2){
    console.log(num1);
    console.log(num2);
    return num1+num2;

}
const result=addfun(45,67);
console.log(result);

// Arrow Function

const arrowfun=(num1,num2)=>{
    console.log(num1);
    console.log(num2);
    return num1+num2;
}

const res=arrowfun(69,96);
document.write(res);


const subfun1=(num1,num2)=>{
    console.log(num1-num2);
}
subfun1(56,23);

// if arrow function body have single statement then {} are optional

const subfun2=(num1,num2)=>console.log(num1-num2);
subfun1(56,23);

// if arrow function body have single statement then {} are optional
// return keyword it is implicitly return the result

const subfun3=(num1,num2)=>num1-num2;

console.log(subfun3(56,23));

// if arrow function has single format argument then () are optional
const cubeFun=num=>num*num*num;
console.log(cubeFun(2));


let arr=[67,89,56,45,89,45];
/*normal for loop */

for(let I=0; I<=arr.length-1; I++){
    console.log(arr[I]);
}
console.log("-------------------");

/* for of loop */
for (let arrvalue of arr){
    console.log(arrvalue);
}
console.log("-------------------");
/* forEach */
arr.forEach((vl)=>console.log(vl));

/* <60*/
const filterarr=arr.filter((val)=>val<60);
console.log(filterarr);
/* function chaining */
arr.filter((val)=>val<60).forEach((filtval)=>console.log(filtval))


const names=[ 'Pranit','amol','Aman','Kapil'];

const capA=names.filter(name => name.startsWith("P"));

const cap=names.filter(name=>name.startsWith("K"));
names.filter(name=>name.startsWith("A")).forEach((val1)=>console.log(val1));
console.log(capA);
console.log(cap);

// 14/2/2025


const nameA=names.find(name=> name.toUpperCase().startsWith("A"));
console.log(nameA);
console.log(nameA.toUpperCase());

const newnames=names.map((name)=>'Neo-'+name);
console.log(newnames);

arr[67,89,56,45,89,45];
// double each number of an array and store into new array
// const newarr = arr.map((val) => val*2).forEach((v)=>console.log(v));

const doublenumber=arr.map((vals)=>vals*2);
console.log(doublenumber);

//add all numbers of array : reduce
// n-1 iteration
// arr.reduce((accumulator,value)=>accumulator+value);

const addallnum=arr.reduce((sum,value)=>sum+value);
console.log(addallnum);

// n iteration
// arr.reduce((accumulator,value)=>accumulator+value,0);
const arr1=[1,2,3,4,5];
const arr2=[6,7,8,9,10];

const sum1=arr1.reduce((acc,val)=>acc+val);
const sum2=arr2.reduce((acc,val)=>acc+val,sum1);
console.log('addition of arr1 and arr2 is:'+sum2);



const names1=[ 'amol','Pranit','Aman','Kapil','om','Zebra'];

const concating=names1.map((name)=>name.charAt(0).toUpperCase()).reduce((acc,letter)=>acc+letter);
console.log('First letter of name1 list in capital:'+concating)


names1.filter((name)=>name.toUpperCase().startsWith('A') || name.toUpperCase().startsWith('Z'))
.forEach((val)=>console.log(val));