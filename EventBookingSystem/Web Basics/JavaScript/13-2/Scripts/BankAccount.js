class BankAccounts{
    accountNumber;
    accountType;
    accountBalance;
    customerId;
    deposit(amount){
        this.accountBalance=this.accountBalance+amount;
        return this.accountBalance;
    }
}

const account1 = new BankAccounts();//default constructor
console.log(account1);