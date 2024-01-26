1. /person
    1.1. GET 
        Request:
            parameter: user_id
        Response:
        200:
        {
            status: 200,
            message: "",
            data: {
                id: 123,
                name: "Ng Van A",
                contacts:[
                    {
                        contact_type: IN_PERSON,
                        profile_name: "",
                        url: ""
                    },
                    {
                        contact_type: PHONE,
                        profile_name: "",
                        url: ""
                    }
                ]
            }
        }

        400:
        {
            status: 400,
            message: "Error",
            data: null
        }
    
2. /bill
    2.1. GET
        Request:
            user_id: 123,
            bill_id: 1,
            platform: IN_PERSON
        Response:
        200:
        {
            status: 200,
            message: "",
            data: {
                date: dd/mm/yyyy,
                buyer_user: {
                    id: 123
                    name: "Ng Van A",
                    contact: {
                        contact_type: IN_PERSON,
                        profile_name: "",
                        url: ""
                    }
                },
                description: "",
                items:[
                    {
                        item_name: "item1",
                        quantity: 2,
                        single_price: 1.0,
                        total_price: 2.0
                    },
                    {
                        item_name: "item2",
                        quantity: 1,
                        single_price: 10.0,
                        total_price: 10.0
                    }
                ] ,
                total: 12.0,
                wallet_used: "wallet_1"
            }
        }
        300:
        {
            status: 300,
            message: "User does not have enough permission",
            data: null
        }
        400:
        {
            status: 400,
            message: "Error",
            data: null
        }

3. /wallet
    3.1. POST
        Request:
            content_type: application/json
            body:
            {
                user_id: 123,
                wallet_name: ""
            }
        Response:
        200:
        {
            status: 200,
            message: "Get wallets", // when wallet_name is empty
            data: {
                user: {
                    id: 123,
                    name: "Ng Van A"
                },
                wallets:[
                    {
                        name: "wallet_1",
                        balance: 0.0
                    },
                    {
                        name: "wallet_2",
                        balance: 0.0
                    }
                ]
            }
        }
        201:
        {
            status: 201,
            message: "Get specific wallet" // when wallet_name is not empty
            data: {
                user:{
                    id: 123,
                    name: "Ng Van A"
                },
                wallet: {
                    name: "wallet_1",
                    balance: 0.0
                }
            }
        }
        300:
        {
            status: 300,
            message: "User does not have enough permission",
            data: null
        }
        400:
        {
            status: 400,
            message: "Error",
            data: null
        }