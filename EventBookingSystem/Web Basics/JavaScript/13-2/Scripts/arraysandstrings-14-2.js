//dynamic , no type restriction , mutable: changes to existing object

let arr1=[56,74];
let arr2=[69,'pranit',6788,true];
let arr3=['pranit','sakthish'];

arr1[2]=77; // length increased
arr1[0]=34; // replace
console.log(arr1);
arr1.push(89); // add new values from back
console.log(arr1);
arr1.unshift(11); // add new values from front
console.log(arr1);
//pop, shift
arr2.pop(); //remove elements from back 
console.log(arr2);
arr2.shift(); //remove elements from fornt
console.log(arr2);

let arr4=new Array(); //length=0
let arr5=new Array(78,66,444,56,55,44); //length=3
let arr6=new Array(5); // length=5
let arr7=new Array('Hi','Pranit','Patil'); //length=1

// splice,includes,join,sort,reverse

// splice
arr5.splice(2,1,99,77,101); //in splice(index,number of removeing elements,value add at index,val2,val3)
console.log(arr5);

// includes: checks the value is available in array or not and give val in boolean 
// like true and false
console.log(arr5.includes(44));
console.log(arr5.includes(17));

// Join
// in join what ever you write that element join after every 
// element of array
// Delimeter
let joinstr=arr5.join(',');
console.log(joinstr)

// sort
//sort using first digit of numbers
arr5.sort();
console.log(arr5);
//for ascending sorting 
arr5.sort((a,b)=>a-b);
console.log(arr5);

//for descending sorting 
arr5.sort((a,b)=>b-a);
console.log(arr5);

// Reverse :it just reverse array
// arr5.reverse();
// console.log(arr5);

arr7.reverse();//mutable
console.log(arr7);




// self study: implement other array API functions

let s1=""; //Primitive
let s2="Hello";
console.log(typeof s2);

let s3=new String();
let s4 = new String("India is my country"); //object of type of String
console.log(typeof s4);
console.log(s4 instanceof String);

// String Objects are immutable
s4.toUpperCase();
console.log(s4);

let uppercase=s4.toUpperCase();
console.log(uppercase);

let city="Solapur";
city=city.concat("Kolhapur"); //ref used same to point to new memory location
console.log(city);

const a=89;
// a=99;  it give Error

const company ="neosoft";
// company=company.concat("Rabale");
const concat1=company.concat(" Rabale");
console.log(concat1);


let n1=69;
let n2=69;
console.log(n1==n2);


let india1=new String('india');
let india2=new String('india');
console.log(india1==india2); // memory  location  compare
console.log(india1.valueOf()==india2.valueOf()); // value compare


const c1="neosoft";
const c2="neosoft";
console.log(c1==c2); // mem loc  true
console.log(c1.valueOf()==c2.valueOf()); // true

console.log("--------------");

let v1=90;
let v2='90';
console.log(v1==v2);//true , loose type checking
console.log(v1===v2);//false , strict type checking

console.log("--------------");
 let str1 = new String(56);
 let str2 = new String('56');
 console.log(str1==str2); //ml false
 console.log(str1===str2);//ml false

//  replace and replaceall ,charAt ,indexof, lastindexof,includes,split

//  Replace  it just replace first occurrence
let rep = "apple banana apple orange";
 let text=rep.replace("apple", "grape")
 console.log(text);
 
//  ReplaceAll  replace all occurrence

 let text1=rep.replaceAll("apple", "grape")
 console.log(text1);
 
// Split means string converts into array using delimeter
// slice, substring : trainer
const message="hello how r u?";

console.log(message.substring(1,4));
console.log(message.slice(1,4));

console.log(message.substring(1));
console.log(message.slice(1));

console.log(message.substring(-1)); // - to 0
console.log(message.slice(-1)); 

console.log(message.substring(-1, 5)); // - to 0, 5
console.log(message.slice(-1, 5));  // empty string