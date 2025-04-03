export class Register {
    firstName?:string;
    lastName?:string;
    email?:string;
    password?:string;

    constructor(firstName:string,
        lastName:string,
        email:string,
        password:string) {
        
        this.firstName=firstName;
        this.lastName=lastName;
        this.email=email;
        this.password=password;
    }


}

export class registerResponceModel{
    userId:string;

    
    constructor(userId:string) {
        this.userId=userId;
    }

}



// [Required]
// public string FirstName { get; set; }
// [Required]
// public string LastName { get; set; }
// [Required]
// [EmailAddress]
// public string Email { get; set; } = string.Empty;
// [Required]
// public string Password { get; set; }