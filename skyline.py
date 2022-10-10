import json
import time
import random


def main():

    while True:
        
        result = read()
        Tx1 = result[0]
        Rx1 = result[1]

        write()

        result2 = read()
        Tx2 = result2[0]
        Rx2 = result2[1]

        bitrate_tx = (Tx2-Tx1)*2
        bitrate_rx = (Rx2-Rx1)*2
        print("O bitrate do TX é : " + str(bitrate_tx) )
        print("O bitrate do RX é : " + str(bitrate_rx) )

        time.sleep(0.5)
    

def read():
    r = open('vendor.json')
    data = json.load(r)
    Tx = data['NIC'][0]['TX']
    Rx = data['NIC'][0]['RX']

    return Tx, Rx


def write():
    with open('vendor.json', 'r+') as f:
        data = json.load(f)
        rand_tx = random.randrange(50,200)
        rand_rx = random.randrange(50,200)
        data['NIC'][0]['TX'] = int(data['NIC'][0]['TX']) + rand_tx
        data['NIC'][0]['RX'] = int(data['NIC'][0]['RX']) + rand_rx
        f.seek(0)       
        json.dump(data, f, indent=4)
        f.truncate()     


if __name__ == "__main__":
    main()



