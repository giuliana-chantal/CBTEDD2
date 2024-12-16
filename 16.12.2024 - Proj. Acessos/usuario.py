class Usuario:
    def __init__(self, id, nome):
        self.id = id
        self.nome = nome
        self.ambientes = []

    def concederPermissao(self, ambiente):
        if ambiente not in self.ambientes:
            self.ambientes.append(ambiente)
            return True
        return False

    def revogarPermissao(self, ambiente):
        if ambiente in self.ambientes:
            self.ambientes.remove(ambiente)
            return True
        return False
