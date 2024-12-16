from collections import deque

class Ambiente:
    def __init__(self, id, nome):
        self.id = id
        self.nome = nome
        self.logs = deque(maxlen=100)

    def registrarLog(self, log):
        self.logs.append(log)
