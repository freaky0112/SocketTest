package com.freaky.main;

import com.freaky.common.Constant;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

/**
 * Created by Freaky on 2015/11/25.
 */
public class Server {
    //端口
    private int listionPort;
    private String savePath;

    /**
     * 构造类
     * @param listionPort 侦听端口
     * @param savePath
     * @throws Exception
     */
    Server(int listionPort, String savePath) throws Exception {
        this.listionPort = listionPort;
        this.savePath=savePath;

        File file = new File(savePath);
        if (!file.exists() && !file.mkdirs()) {
            throw new IOException("无法创建文件夹 " + savePath);
        }
    }

    /**
     * 开始服务
     */
    public void start() {
        new ListenThread().start();
        //return null;
    }

    /**
     *侦听线程
     */
    private class ListenThread extends Thread {
        @Override
        public void run(){
            try {
                ServerSocket server=new ServerSocket(listionPort);
                while (true){
                    Socket socket=server.accept();
                    new HandleThread(socket).start();
                }
            }catch (IOException e){
                e.printStackTrace();
            }
        }
    }

    /**
     * 读取流并保存文件
     */
    private class HandleThread extends Thread{
        private Socket socket;
        private HandleThread(Socket socket){
            this.socket=socket;
        }

        @Override
        public void run(){
            try {
                InputStream is=socket.getInputStream();
                readAndSave(is);
            } catch (IOException e) {
                e.printStackTrace();
            }finally {
                try {
                    socket.close();
                } catch (IOException e) {
                    //e.printStackTrace();
                }
            }
        }

        /**
         * 读取并保存文件
         * @param is
         * @throws IOException
         */
        private  void readAndSave(InputStream is) throws IOException{
            String fileName=getFileName(is);
            int file_len=readInteger(is);
            System.out.println("接收文件：" + fileName + "，长度：" + file_len);
            //BufferedWriter out = new BufferedWriter(new FileWriter(savePath+"aa.xml"));
            //out.write(fileName);
            //out.flush();
            //out.close();
            readAndSave0(is,savePath+fileName,file_len);
        }

        private void readAndSave0(InputStream is, String path,int file_len) throws IOException{
            FileOutputStream os=getFileOS(path);
            String fileName=getFileName(is);
            System.out.println(fileName);
            readAndWrite(is,os,file_len);
            os.close();

        }

        /**
         * 边读边写
         * @param is
         * @param os
         * @param size
         */
        private void readAndWrite(InputStream is, FileOutputStream os, int size) throws IOException {
            byte[] buffer=new byte[4096];
            int count=0;
            while (count<size){
                int n=is.read(buffer);
                os.write(buffer,0,n);;
                count+=n;
            }
        }

        /**
         * 创建文件并返回输出流
         * @param path 文件目录
         * @return
         * @throws IOException
         */
        private FileOutputStream getFileOS(String path) throws IOException{
            File file=new File(path);
            if (!file.exists()){
                file.createNewFile();
            }
            return  new FileOutputStream(file);
        }

        /**
         * 读取文件名
         * @param is
         * @throws IOException
         */
        private String  getFileName(InputStream is) throws IOException{
            int name_len=readInteger(is);
            byte[] result=new byte[name_len];
            is.read(result);
            return new String(result);
        }

        /**
         * 读取数字
         * @param is
         * @return
         * @throws IOException
         */
        private int  readInteger(InputStream is) throws IOException{
            byte[] bytes=new byte[4];
            is.read(bytes);
            return Constant.b2i(bytes);
        }
    }



}
