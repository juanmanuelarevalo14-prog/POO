class Persona:
    def __init__(self, nombre, edad):
        self.nombre = nombre
        self.edad = edad

    def saludar(self):
        return f"hola soy {self.nombre}"

    #uso
p = Persona("juan", 20) 
print(p.saludar())
