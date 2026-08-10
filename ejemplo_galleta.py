
class Galleta:
    def __init__(self, sabor) -> None:
        self.sabor: Galleta = sabor

g1 = Galleta("chocolate")
g2 = Galleta("limon")

print(g1 is g2)
print(g1.sabor == g2.sabor)   
