#!/usr/bin/python
from BaseHTTPServer import BaseHTTPRequestHandler,HTTPServer
import threading
import datetime

PORT_NUMBER = 8080
feedbackFileLock = threading.Lock()

class MyRequestHandler(BaseHTTPRequestHandler):

	def writeResponse(self, respondString):
		self.send_response(200)
		self.send_header('Content-type', 'text/plain')
		self.send_header('Content-Length', '%i' % len(respondString))
		self.end_headers()
		self.wfile.write(respondString)

	def do_GET(self):
		respondString = ""
		if self.path == "/":
			respondString = "A Jill Assistant Web Server"
		elif self.path == "/recipients":
			f = open("Recipients.txt")
			respondString = f.read()
			f.close()
			
		if len(respondString) > 0:
			self.writeResponse(respondString)
		
	def do_POST(self):
		respondString = ""
		if self.path == "/feedback":
			respondString = "Got Feedback"
			content_length = int(self.headers['Content-Length'])
			post_data = self.rfile.read(content_length)
			print "Feedback is: %s" % post_data
			feedbackFileLock.acquire()
			f = open("Feedback.txt", 'a')
			curDateTime = datetime.datetime.now().strftime("%Y-%m-%d %H:%M")
			f.write(curDateTime + ";" + post_data + "\r")
			f.close()
			feedbackFileLock.release()
			
		if len(respondString) > 0:
			self.writeResponse(respondString)
	
try:
	server = HTTPServer(('', PORT_NUMBER), MyRequestHandler)
	print 'Started httpserver on port %i' % PORT_NUMBER
	
	server.serve_forever()
	
except KeyboardInterrupt:
	print 'End recieved'
	server.socket.close()