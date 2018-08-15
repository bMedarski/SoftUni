class Gladiator:
    def __init__(self,name):
        self.name = name
        self.techniques = {}
        self.techniques_list = []
        self.total = self.total_skill()

    def total_skill(self):
        total = 0
        for t in self.techniques:
            total += self.techniques[t]
        return total

    def __str__(self):
        print(f"{self.name}: {self.total_skill()} skill")
        self.techniques_list = sorted(self.techniques, key=lambda s: s)
        self.techniques_list = sorted(self.techniques,key=lambda s:self.techniques[s],reverse=True)

        # print(self.techniques)
        # print(self.techniques_list)
        for t in self.techniques_list:
            print(f"- {t} <!> {self.techniques[t]}")

gladiators = []

while True:
    data = input()
    if data == "Ave Cesar":
        break

    data_args = data.split(" -> ")
    if len(data_args)==3:
        name = data_args[0]
        technique = data_args[1]
        skill = int(data_args[2])

        exist = False
        for g in gladiators:
            if g.name == name:
                exist = True
                is_tech = False
                if technique in g.techniques:
                    if g.techniques[technique] < skill:
                        g.techniques[technique]=skill
                else:
                    g.techniques[technique]=skill

        if not exist:
            gladiator = Gladiator(name)
            gladiator.techniques[technique] = skill
            gladiators.append(gladiator)

    else:
        data_args = data.split(" vs ")
        first_name = data_args[0]
        second_name = data_args[1]

        first = [g for g in gladiators if g.name==first_name]
        second = [g for g in gladiators if g.name == second_name]
        if len(first)==0 or len(second)==0:
            continue
        else:
            first_glad = first[0]
            second_glad = second[0]

            if set(first_glad.techniques) & set(second_glad.techniques):
                common = list(set(first_glad.techniques).intersection(second_glad.techniques))
                if first_glad.techniques[common[0]] > second_glad.techniques[common[0]]:
                    gladiators.remove(second_glad)
                else:
                    gladiators.remove(first_glad)
            else:
                continue

gladiators = sorted(gladiators,key=lambda g: g.name)
gladiators = sorted(gladiators,key=lambda g: g.total_skill(),reverse=True)
for g in gladiators:
    g.__str__()
