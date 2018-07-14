class BankAccount:
    def __init__(self,bank,account_name,account_balance):
        self.bank = bank
        self.account_name = account_name
        self.account_balance = account_balance


banks = []

while True:
    user_input = input()
    if user_input == "end":
        break

    bank_args = user_input.split(" | ")
    bank_acc = BankAccount(bank_args[0],bank_args[1],float(bank_args[2]))
    banks.append(bank_acc)

banks = sorted(banks, key=lambda bank: len(bank.bank))
banks = sorted(banks, key=lambda bank: bank.account_balance, reverse=True)


for b in banks:
    print(f"{b.account_name} -> {b.account_balance:.2f} ({b.bank})")