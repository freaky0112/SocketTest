package com.freaky;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

/**
 * Created by Freaky on 2016/1/25.
 */
public class Server {
    private int listonPort;

    public Server(int listonPort) {
        this.listonPort = listonPort;
    }

    public void init() {
        try {
            ServerSocket serverSocket = new ServerSocket(listonPort);
            while (true) {
                Socket socket = serverSocket.accept();
                new HandlerThread(socket);
            }
        } catch (Exception ex) {
            System.out.print("Server error {0}"+ ex.getMessage());
        }
    }

    private class HandlerThread implements Runnable {
        private Socket socket;
        private BufferedReader in;
        private PrintWriter out;
        public HandlerThread(Socket socket) {
            this.socket = socket;
            new Thread(this).start();
        }

        public void run() {
            try {
                System.out.printf("Get a new connect by "+socket.getInetAddress()+"\n");
//                DataInputStream input = new DataInputStream(socket.getInputStream());
//                String clinetInputStr=input.readUTF();
//                DataOutputStream output=new DataOutputStream(socket.getOutputStream());
                while(socket.isConnected() ) {
                    in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                    String msg="client says:" + in.readLine();
                    System.out.println(msg);
                    out=new PrintWriter(socket.getOutputStream(),true);
                    out.println(msg.replace("\n",""));
                }

            } catch (Exception ex) {
                System.out.print("Server run error "+ex.getMessage()+"\n");
            }finally {
                try {
                    if (in.readLine().equals("finish")){
                        socket.close();
                    }
                } catch (IOException e) {
                    //e.printStackTrace();
                }
            }
        }
    }
}
