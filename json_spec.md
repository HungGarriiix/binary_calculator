1. person.json:
{
    id: 123,
    name: "Ng Van A",
    contacts: // can be emptied
    [
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

2. wallets.json:
{
    user_id: 123,
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

3. bills.json:
{
    date: dd/mm/yyyy,
    buyer_user_id: 123,
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

4. loans.json:

5. login.json: