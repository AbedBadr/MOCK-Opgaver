from sense_hat import SenseHat

sense = SenseHat()

blue = (0, 0, 255)
green = (0, 255, 0)
red = (255, 0, 0)

while True: 
    temp = sense.get_temperature()
    if temp < 18:
      sense.clear(blue)
    elif temp > 18 and temp < 22:
      sense.clear(green)
    else:
      sense.clear(red)