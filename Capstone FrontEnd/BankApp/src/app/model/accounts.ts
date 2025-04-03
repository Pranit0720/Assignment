export interface Accounts {
  id: number;
  userId: string;
  accountNumber: number;
  balance: number;
  accountTypes: AccountTypes;
  createdDate: Date;
  transactions?: Transactions[];
}
export interface Transactions {
    id: number;
    accountId: number;
    account?: Accounts;
    transactionType:TransactionTypes;
    amount:number;
    date:Date;
    description:string
  
  }
export enum AccountTypes {
  Saving_Account = 1,
  Current_Account,
  Joint_Account,
  Salary_Account
}
export enum TransactionTypes {
  credit = 1,
  Debit
}
export class TransactionAddModel{
    amount:number;
    description:string;
    
    constructor(amount:number,description:string) {
        this.amount=amount;
        this.description=description
        
    }
}

export class TransferModel{
    accountNumber:number;
    amount:number;
    
    
    constructor(amount:number,accountNumber:number) {
        this.accountNumber=accountNumber;
        this.amount=amount;
        
        
    }
}

export class AddAccount{

  accountNumber:number;
  balance:number;
  accountTypes: AccountTypes;
  
  constructor(accountNumber:number,balance:number,accountType: AccountTypes) {
    this.accountNumber=accountNumber;
    this.balance=balance;
    this.accountTypes=accountType;
  }


}


// [Required]
// public long AccountNumber { get; set; }
// [Required]
// public decimal Balance { get; set; }
// [Required]
// public AccountTypes AccountTypes { get; set; }




// [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
// public int Id { get; set; }
// [Required]
// public int AccountId { get; set; }
// [JsonIgnore]
// [ForeignKey("AccountId")]
// public Accounts? Accounts { get; set; }
// [Required]
// public TransactionTypes TransactionType { get; set; }
// [Required]
// public decimal Amount { get; set; }
// [Required]
// public DateTime Date { get; set; }

// // Stores additional details about the transaction
// [Required]
// public string Description { get; set; }

// Saving_Account=1,
// Current_Account,
// Joint_Account,
// Salary_Account
// [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
// public int ID { get; set; }
// [Required]
// public string UserId { get; set; } = string.Empty;

// [Required]
// //[MinLength(10,ErrorMessage ="Account number must be 10 digit!!!")]
// public long AccountNumber { get; set; }
// [Required]
// public decimal Balance { get; set; }
// [Required]
// public AccountTypes AccountTypes { get; set; }
// [Required]
// public DateTime CreatedDate { get; set; }= DateTime.Now;
// [JsonIgnore]

// public ICollection<Transactions>? Transactions { get; set; }
