<?php

class MessageMapper extends Mapper
{
    public function getMessageByChannel($channel, $params)
    {
        $row_limit = array_key_exists('limit', $params) ? $params['limit'] : "50";
        $offset = array_key_exists('offset', $params) ? $params['offset'] : "0";
        $stmt = $this->db->prepare("SELECT * FROM message WHERE channel = :channel LIMIT $offset, $row_limit");
        $stmt->execute(["channel" => $channel]);
        $results = [];
        while ($row = $stmt->fetch()) {
            $results[] = new MessageEntity($row);
        }
        return $results;
    }

    public function save(MessageEntity $message)
    {
        $stmt = $this->db->prepare("INSERT INTO message(message, timestamp, sender, channel) VALUES (:message, :timestamp, :sender, :channel)");
        $result = $stmt->execute([
            "message" => $message->getMessage(),
            "timestamp" => $message->getTimestamp(),
            "sender" => $message->getSender(),
            "channel" => $channel->getChannel(),
        ]);
        if (!$result) {
            throw new Exception("Could not save record");
        }
    }
}
