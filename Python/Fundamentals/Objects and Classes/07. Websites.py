class Website:
    def __init__(self,host,domain):
        self.host = host
        self.domain = domain
        self.queries = []

    def add_queries(self,list):
        for q in list:
            self.queries.append(q)

websites = []

while True:
    user_input = input()
    if user_input == "end":
        break

    website_args = user_input.split(" | ")

    host = website_args[0]
    domain = website_args[1]

    website = Website(host,domain)
    if len(website_args)>2:
        queries = website_args[2].split(",")
        website.add_queries(queries)

    websites.append(website)

for w in websites:
    print(f"https://www.{w.host}.{w.domain}",end="")
    if len(w.queries)>0:
        print(f"/query?=",end="")
        print(f"[",end="")
        print("]&[".join(w.queries),end="")
        print("]")